// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#include <curses.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/param.h>
#include <unistd.h>

#include "process.h"
#include "io.h"
#include <errno.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

void printUsage(const char *prog)
{
    printf("Usage: %s <file-name> <count>\n", prog);
}

void CheckError(int err, const char *desc, const char *path)
{
    if (err != 0)
    {
        printf("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Failed to %s on %s; error: %d\n", desc, path, err);
        exit(1);
    }
    else
    {
        printf("%s succeeded on %s\n", desc, path);
    }
}

int childMain(const char *sourcePath, int i)
{
    char hlPathSrc[PATH_MAX];
    char hlPathDest[PATH_MAX];
    sprintf(hlPathSrc, "%s.hl.%d", sourcePath, i);
    sprintf(hlPathDest, "%s.hl.moved.%d", sourcePath, i);

    int err = link(sourcePath, hlPathSrc);
    CheckError(err, "CreateHardLink", hlPathSrc);

    err = rename(hlPathSrc, hlPathDest);
    CheckError(err, "Move", hlPathDest);

    int handle;
    while ((handle = open(hlPathDest,
                          O_SHLOCK | O_RDONLY,
                          S_IRGRP | S_IRUSR | S_IROTH)) < 0
           && errno == EINTR);
    CheckError(handle > 0 ? 0 : errno, "Open", hlPathDest);

    StatBuffer buff;
    err = StatFileDescriptor(handle, &buff, sizeof(buff));
    CheckError(err, "StatFile", hlPathDest);

    char volPath[MAXPATHLEN];
    sprintf(volPath, "/.vol/%lld/%lld", buff.st_dev, buff.st_ino);
    buff.st_mtimespec_nsec -= 1;
    err = SetTimeStampsForFilePath(volPath, false, buff);
    CheckError(err, "SetTimeStamps", volPath);

    close(handle);
    printf("Closed: %s\n", hlPathDest);

    return 0;
}

int main(int argc, const char * argv[])
{
    if (argc < 3)
    {
        printUsage(argv[0]);
        return -1;
    }

    const char *sourcePath = argv[1];
    int numRepeat = atoi(argv[2]);

    FILE *file = fopen(sourcePath, "r");
    if (file == NULL)
    {
        printf("Error: file '%s' not found.\n", sourcePath);
        return -2;
    }
    fclose(file);

    printf("Num: %d\n", numRepeat);
    pid_t* children = malloc(sizeof(pid_t) * numRepeat);
    for (int i = 0; i < numRepeat; i++)
    {
        pid_t pid = fork();
        if (pid == 0)
        {
            // child
            exit(childMain(sourcePath, i));
        }
        else
        {
            // parent
            children[i] = pid;
        }
    }

    bool ok = true;
    for (int i = 0; i < numRepeat; i++)
    {
        int status;
        waitpid(children[i], &status, 0);
        ok = ok && status == 0;
    }

    free(children);

    printf("======= OK: %s", ok ? "true" : "false");
}

int main2(int argc, const char * argv[])
{
    if (argc < 2)
    {
        // Dump path must be given as parameter
        return -1;
    }

    char *buffer = calloc(MAXPATHLEN, sizeof(char));
    SetupProcessDumps(argv[1], buffer, MAXPATHLEN);

    while(true)
    {
        fprintf(stdout, "kern.corefile=%s\n", buffer);
        fflush(stdout);
        sleep(1);
    }

    return 0;
}
