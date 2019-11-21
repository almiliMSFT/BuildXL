// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import * as Bash from "Bash";
import {Cmd, Artifact, Transformer} from "Sdk.Transformers";

@@public
export const test1 = (() => {
    return Bash.runBashCommand("absp", [
        Cmd.option("cd ", Artifact.none(p`.`)),
        Cmd.rawArgument(" && "),
        Cmd.option("ls ", Artifact.input(f`sdir`)),
        Cmd.rawArgument(" && "),
        Cmd.rawArgument("if ls sdir/aca; then echo 'yes'; else echo 'no'; fi")
    ], true);
})();