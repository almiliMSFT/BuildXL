// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#include "AriaLogger.hpp"

#ifdef MICROSOFT_INTERNAL // Only needed for internal builds

 LOGMANAGER_INSTANCE

//// Aria logger class definition

AriaLogger::AriaLogger(const char* token, const char *dbPath)
{
    token_ = token;
    dbPath_ = dbPath;

    auto& config = LogManager::GetLogConfiguration();
    config[CFG_INT_MAX_TEARDOWN_TIME] = 15;
    // config[CFG_STR_CACHE_FILE_PATH] = dbPath; // not necessary

    logger_ = LogManager::Initialize(token);
    LogManager::SetTransmitProfile(TransmitProfile_NearRealTime);
}

AriaLogger::~AriaLogger()
{
    printf("============== calling FlushAndTeardown\n");
    LogManager::FlushAndTeardown();
}

ILogger *AriaLogger::GetLogger() const
{
    return logger_;
};

//// External Interface

int WINAPI Get42() { return 42; }

AriaLogger* WINAPI CreateAriaLogger(const char *token, const char *dbPath)
{
    AriaLogger *arl = new AriaLogger(token, dbPath);
    printf("==== new ArriaLogger: @%p\n", arl);
    return arl;
}

void WINAPI DisposeAriaLogger(const AriaLogger *logger)
{
    if (logger != nullptr)
    {
        printf("==== delete @%p\n", logger);
        delete logger;
    }
}

void WINAPI LogEvent(const AriaLogger *logger, const char *eventName, int eventPropertiesLength, const AriaEventProperty *eventProperties)
{
    if (logger != nullptr)
    {
        EventProperties props;
        props.SetName(eventName);
        for (int i = 0; i < eventPropertiesLength; i++)
        {
            const char *propName = eventProperties[i].name;
            const char *propValue = eventProperties[i].value;
            int64_t piiOrValue = eventProperties[i].piiOrLongValue;

            if (propValue == nullptr)
            {
                props.SetProperty(propName, piiOrValue);
                printf("======== %s::%s = %lld\n", eventName, propName, piiOrValue);
            }
            else if (piiOrValue == (int)PiiKind::PiiKind_None)
            {
                props.SetProperty(propName, propValue);
                printf("======== %s::%s = %s\n", eventName, propName, propValue);
            }
            else
            {
                props.SetProperty(propName, propValue, static_cast<PiiKind>(piiOrValue));
                printf("======== %s::%s = %s (%lld)\n", eventName, propName, propValue, piiOrValue);
            }
        }

        ILogger *log = logger->GetLogger();
        printf("==== @%p.LogEvent('%s')\n", log, eventName);
        log->LogEvent(props);
    }
}

#endif
