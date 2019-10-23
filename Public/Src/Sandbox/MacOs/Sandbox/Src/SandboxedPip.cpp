// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#include "SandboxedPip.hpp"

#define super OSObject

OSDefineMetaClassAndStructors(SandboxedPip, OSObject)

bool SandboxedPip::init(pid_t clientPid, pid_t processPid, Buffer *payload)
{
    if (!super::init())
    {
        return false;
    }

    clientPid_        = clientPid;
    payload_          = payload;
    processId_        = processPid;
    processTreeCount_ = 1;
    counters_         = {0};

    payload_->retain();

    fam_.init((BYTE*)payload_->getBytes(), payload_->getSize());
    if (fam_.HasErrors())
    {
        log_error("Could not parse FileAccessManifest: %s", fam_.Error());
        return false;
    }

    lastPathLookup_ = ThreadLocal::create();
    if (!lastPathLookup_)
    {
        return false;
    }
    
    return true;
}

void SandboxedPip::free()
{
    if (lastPathLookup_ != nullptr)
    {
        log_verbose(
            g_bxl_verbose_logging,
           "Process Stats PID(%d) :: #cache hits = %d, #cache misses = %d, thread local size = %d",
            processId_, counters_.numCacheHits.count(), counters_.numCacheMisses.count(),
            lastPathLookup_->getCount());
    }

    OSSafeReleaseNULL(payload_);
    OSSafeReleaseNULL(lastPathLookup_);
    super::free();
}

SandboxedPip* SandboxedPip::create(uint32_t pipOrdinalId, pid_t clientPid, pid_t processPid, Buffer *payload,
                                   void *cacheLookupState, cache_lookup_fn cacheLookup)
{
    SandboxedPip *instance = new SandboxedPip;
    if (instance == nullptr)
    {
        log_error("Failed to create a new ProcessObject (PID: %d) for Client (PID: %d)", processPid, clientPid);
        return nullptr;
    }
    
    bool initialized = instance->init(clientPid, processPid, payload);
    if (!initialized)
    {
        // init already logged an error message describing what failed
        OSSafeReleaseNULL(instance);
        return nullptr;
    }

    instance->pipOrdinalId_ = pipOrdinalId;
    instance->cacheLookupState_ = cacheLookupState;
    instance->cacheLookup_ = cacheLookup;
    
    return instance;
}

PipInfo SandboxedPip::introspect() const
{
    return
    {
        .pid                 = getProcessId(),
        .clientPid           = getClientPid(),
        .pipId               = getPipId(),
        .treeSize            = getTreeSize(),
        .counters            = counters_,
        .numReportedChildren = 0,
        .children            = {0}
    };
}

#undef super
