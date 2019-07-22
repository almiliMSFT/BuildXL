// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Utilities.Instrumentation.Common;
using VSCode.DebugAdapter;
using VSCode.DebugProtocol;

namespace BuildXL.Execution.Analyzer
{
    public class Session : ISession
    {
        private static readonly Thread s_singleThread = new Thread(1, "Main");

        private LoggingContext LoggingContext { get; }
        private IDebugger Debugger { get; }

        private readonly Handles<FrameContext> m_scopeHandles = new Handles<FrameContext>();
        private readonly Barrier m_sessionInitializedBarrier = new Barrier();
        private readonly Renderer m_renderer;

        public Session(LoggingContext loggingContext, IDebugger debugger)
        {
            LoggingContext = loggingContext;
            Debugger = debugger;
        }

        public void Attach(IAttachCommand cmd)
        {
            cmd.SendResult(null);
            m_sessionInitializedBarrier.Signal();
        }

        public void ConfigurationDone(IConfigurationDoneCommand cmd)
        {
            cmd.SendResult(null);
        }

        public void Continue(IContinueCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(IDisconnectCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Evaluate(IEvaluateCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Initialize(IInitializeCommand cmd)
        {
            Debugger.SendEvent(new InitializedEvent());

            var capabilities = new Capabilities(
                supportsConfigurationDoneRequest: true,
                supportsConditionalBreakpoints: false,
                supportsEvaluateForHovers: false,
                supportsFunctionBreakpoints: false,
                supportsCompletionsRequest: false);

            cmd.SendResult(capabilities);
        }

        public void Launch(ILaunchCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Next(INextCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Pause(IPauseCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Scopes(IScopesCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void SetBreakpoints(ISetBreakpointsCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void SetExceptionBreakpoints(ISetExceptionBreakpointsCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void SetFunctionBreakpoints(ISetFunctionBreakpointsCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Source(ISourceCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Threads(IThreadsCommand cmd)
        {
            cmd.SendResult(new ThreadsResult(new List<Thread> { s_singleThread }));
        }

        public void StackTrace(IStackTraceCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void StepIn(IStepInCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void StepOut(IStepOutCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Variables(IVariablesCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void Completions(ICompletionsCommand cmd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     A barrier for waiting until the debug session has been initialized
        ///     (the <code cref="Attach"/> request has been received).
        /// </summary>
        public void WaitSessionInitialized()
        {
            m_sessionInitializedBarrier.Wait();
        }
    }
}
