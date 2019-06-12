#!/bin/bash

export MacOsScriptsDir="$(cd `dirname ${BASH_SOURCE[0]}` && pwd)/../../Public/Src/Sandbox/MacOs/scripts"

source "${MacOsScriptsDir}/env.sh"

export CACHE_ROOT=/bxl
export CACHE_NAME=almili-test-logging-1
export CACHE_SCENARIO=scenario-$CACHE_NAME
