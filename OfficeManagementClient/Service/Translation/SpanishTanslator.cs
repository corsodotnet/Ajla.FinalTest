using OfficeManagementClient.Contratti.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.Translation
{
    internal class SpanishTanslator : ITranslator
    {
        public string Translate(string text)
        {
            if (text == "HOLA")

            {
                text = "ciao da Spanish translator";
            }
            return text;

        }
    }
}
