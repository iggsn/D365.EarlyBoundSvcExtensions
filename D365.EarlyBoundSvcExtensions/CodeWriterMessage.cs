using System;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    public class CodeWriterMessage : ICodeWriterMessageFilterService
    {
        public bool GenerateSdkMessage(SdkMessage sdkMessage, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateSdkMessagePair(SdkMessagePair sdkMessagePair, IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}
