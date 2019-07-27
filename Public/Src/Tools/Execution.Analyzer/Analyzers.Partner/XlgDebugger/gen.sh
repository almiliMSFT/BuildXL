#!/bin/bash

java -Xmx500M org.antlr.v4.Tool -Dlanguage=CSharp -package BuildXL.Execution.Analyzer.JPath JPath.g4
