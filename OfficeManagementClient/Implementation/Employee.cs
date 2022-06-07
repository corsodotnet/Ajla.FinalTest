using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Implementation
{
    public class Employee : IEmployee
    {
        public Feedback feedback;



        public void GetFeedback(string code)
        {
            Console.WriteLine(code);
        }


    }
}
