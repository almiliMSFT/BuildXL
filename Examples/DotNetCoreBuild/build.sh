#!/bin/bash

readonly MY_DIR=$(cd `dirname ${BASH_SOURCE[0]}` && pwd)

source "${MY_DIR}/env.sh"

readonly cacheConfigFile=${MY_DIR}/CasaasCacheConfig.json

cat > $cacheConfigFile <<EOF
{
    "LocalCache": {
        "CacheId": "SelfhostCS2L1",
        "Assembly": "BuildXL.Cache.MemoizationStoreAdapter",
        "CacheLogPath": "[BuildXLSelectedLogPath]",
        "Type": "BuildXL.Cache.MemoizationStoreAdapter.MemoizationStoreCacheFactory",
        "CacheRootPath": "${CACHE_ROOT}/cache",
        "UseStreamCAS": false,
        "EnableContentServer": true,
        "EmptyFileHashShortcutEnabled": false,
        "CheckLocalFiles": false,
        "CacheName": "${CACHE_NAME}",
        "GrpcPort": 7089,
        "Scenario": "${CACHE_SCENARIO}"
    },
    "RemoteCache": {
        "Type": "BuildXL.Cache.BuildCacheAdapter.DistributedBuildCacheFactory",
        "Assembly": "BuildXL.Cache.BuildCacheAdapter",
        "CacheId": "RemoteCache",
        "CacheLogPath": "[DominoSelectedLogPath].L3.log",
        "CacheServiceFingerprintEndpoint": "https://artifactsu0.artifacts.visualstudio.com/DefaultCollection",
        "CacheServiceContentEndpoint": "https://artifactsu0.vsblob.visualstudio.com/DefaultCollection",
        "UseBlobContentHashLists": true,
        "CacheKeyBumpTimeMins": 120,
        "CacheNamespace": "${CACHE_NAME}",
        "CacheName": "${CACHE_NAME}",
        "ConnectionRetryCount": 5,
        "ConnectionRetryIntervalSeconds": 5,
        "GrpcPort": 7089,
        "SealUnbackedContentHashLists": false,
        "ConnectionsPerSession": 46,
        "DisableContent": true
    },
    "Type": "BuildXL.Cache.VerticalAggregator.VerticalCacheAggregatorFactory",
    "Assembly": "BuildXL.Cache.VerticalAggregator",
    "RemoteContentIsReadOnly": true
}
EOF

/bin/bash "${MacOsScriptsDir}/bxl.sh"       \
  --config "$MY_DIR/config.dsc"             \
  --symlink-sdks-into "$MY_DIR/sdk"         \
  --buildxl-bin "$BUILDXL_BIN"              \
  /sandboxKind:macOsKext                    \
  /disableProcessRetryOnResourceExhaustion+ \
  /cacheConfigFilePath:"$cacheConfigFile"   \
  "$@"