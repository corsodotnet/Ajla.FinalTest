using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Implementation
{
    internal class LawyerOffice
    {
     
        ManagerOffice manager = new ManagerOffice();


        public void OrdinaFood(FOOD ordine, Feedback feedbackLawyer)
        {
            manager.StartOrdine(ordine, feedbackLawyer);
        }




        public string OrdinaTraduzione(LANGUAGE lang, string text)
        {
            return manager.StartTranslation(lang, text);
        }

       
        public void OrdinaTask(DOCUMENTO documento, Feedback feedbackTaskLawyer)
        {
            manager.StartOrdineTask(documento, feedbackTaskLawyer);
        }


        public void Viaggia(string paese, Feedback feedback)
        {
            manager.CercaViaggio(paese, feedback);
        }


    }
}
