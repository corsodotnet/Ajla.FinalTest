using OfficeManagementClient.Contratti.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.Translation
{
    internal class FactoryTranslation
    {
        public static ITranslator GetTranslator(LANGUAGE language)
        {
            switch (language)
            {
                case LANGUAGE.ENG:
                    return new EnglishTranslator();
                    break;
                case LANGUAGE.GERMAN:
                    return new GermanTranslator();
                    break;
                case LANGUAGE.SPANISH:
                    return new SpanishTanslator();
                    break;
                default: return null;
            }
        }
    }
}
