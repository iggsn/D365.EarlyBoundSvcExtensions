using System;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called during the process of CodeDOM generation, assuming the default instance of ICodeGenerationService,
    /// to determine whether a specific message should be generated.
    /// This should not be used for requests/responses as these are already generated in
    /// Microsoft.Crm.Sdk.Proxy.dll and Microsoft.Xrm.Sdk.dll.
    /// </summary>
    public class CodeWriterMessage : ICodeWriterMessageFilterService
    {
        private ICodeWriterMessageFilterService DefaultService { get; }

        public CodeWriterMessage(ICodeWriterMessageFilterService defaultService)
        {
            DefaultService = defaultService;
        }

        public bool GenerateSdkMessage(SdkMessage sdkMessage, IServiceProvider services)
        {
            return DefaultService.GenerateSdkMessage(sdkMessage, services);
        }

        public bool GenerateSdkMessagePair(SdkMessagePair sdkMessagePair, IServiceProvider services)
        {
            return DefaultService.GenerateSdkMessagePair(sdkMessagePair, services);
        }
    }
}
