using OfficeManagementClient.Contratti.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.Translation
{
    internal class EnglishTranslator : ITranslator
    {
        public string Translate(string text)
        {
            if (text == "HI")

            {
                text = "ciao da English translator";
            }
            return text;
        }
    }
}
