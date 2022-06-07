using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.Translation
{
    internal class TranslationOnlineStore
    {
        public string Translate(LANGUAGE lang, string text)
        {

            var translator = FactoryTranslation.GetTranslator(lang);
            return translator.Translate(text);

        }
    }
}
