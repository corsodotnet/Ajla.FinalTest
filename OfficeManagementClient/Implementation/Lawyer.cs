using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Implementation
{
    internal class Lawyer : Employee
    {
        public LawyerOffice lawyerOffice;



        public void OrdinaTraduzione(LANGUAGE lang, string text)
        {
            Console.WriteLine(lawyerOffice.OrdinaTraduzione(lang, text));

        }

        public Lawyer()
        {
            feedback = GetFeedback;
            lawyerOffice = new LawyerOffice();
        }
        public void OrdinaTaskUfficio(DOCUMENTO documento)
        {
            lawyerOffice.OrdinaTask(documento, feedback);
        }
        public void OrdinazioneCibo(FOOD food)
        {

            lawyerOffice.OrdinaFood(food, feedback);
        }

        public void Viaggia(string paese)
        {
           // Console.Write("Il paese in che vuoi viaggiare è in zona ");
            lawyerOffice.Viaggia(paese, feedback);
        }

    }
}
