using System;
using System.CodeDom;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called after the CodeDOM generation has been completed, assuming the default instance of
    /// ICodeGenerationService. It is useful for generating additional classes, such as the
    /// constants in picklists.
    /// </summary>
    public class CodeCustomization : ICustomizeCodeDomService
    {
        private ICustomizeCodeDomService DefaultService { get; }

        public CodeCustomization(ICustomizeCodeDomService defaultService)
        {
            DefaultService = defaultService;
        }

        public void CustomizeCodeDom(CodeCompileUnit codeUnit, IServiceProvider services)
        {
          DefaultService.CustomizeCodeDom(codeUnit, services);
        }
    }
}
