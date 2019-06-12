#!/bin/bash

readonly MY_DIR=$(cd `dirname ${BASH_SOURCE[0]}` && pwd)

source ${MY_DIR}/env.sh

function printRunningCasaasPid {
    ps -ef | grep ContentStoreApp | grep -v grep | awk '{print $2}'
}


if [[ -z $BUILDXL_BIN ]]; then
    echo "BUILDXL_BIN is not defined"
    exit 1
fi

if [[ ! -f $BUILDXL_BIN/ContentStoreApp ]]; then
    echo "$BUILDXL_BIN/ContentStoreApp not found"
    exit 1
fi

readonly runningCasaasPid=$(printRunningCasaasPid)
if [[ -n $runningCasaasPid ]]; then
    echo "CASaaS process already running: ${runningCasaasPid}. Sending TERM..."
    kill -s TERM $runningCasaasPid
    sleep 1
    readonly checkAgainPid=$(printRunningCasaasPid)
    if [[ -n $checkAgainPid ]]; then
        echo "[ERROR] cound not kill CASaaS"
        exit 1
    fi
fi

readonly casaasArgs=(
  distributedservice
  /dataRootPath:${CACHE_ROOT}/dataRootPath
  /grpcPort:7089
  /cacheName:${CACHE_NAME}
  /cachePath:${CACHE_ROOT}/cache
  /ringId:ring-${CACHE_NAME}
  /stampId:stamp-${CACHE_NAME}
  /scenario:${CACHE_SCENARIO}
  /useDistributedGrpc:true
  /settingsPath:${MY_DIR}/distContSet.json
  /logdirectorypath:${CACHE_ROOT}/logs)

${BUILDXL_BIN}/ContentStoreApp "${casaasArgs[@]}" # <&- > casaas.stdout &
# readonly casaasPid=$!
# sleep 1
# echo "Started casaas process: $casaasPid"
# cat casaas.stdout
# disown $casaasPid
