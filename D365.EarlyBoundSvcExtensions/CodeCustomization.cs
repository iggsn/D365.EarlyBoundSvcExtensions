using System;
using System.CodeDom;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    public class CodeCustomization : ICustomizeCodeDomService
    {
        public void CustomizeCodeDom(CodeCompileUnit codeUnit, IServiceProvider services)
        {
           throw new NotImplementedException();
        }
    }
}
