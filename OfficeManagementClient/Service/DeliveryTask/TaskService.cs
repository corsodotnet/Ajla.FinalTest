using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.DeliveryTask
{
    public class TaskService
    {
        public string TaskServiceName;
        public TASKTYPE TaskServiceType;
        public List<OfficeTask> OfficeTask;
        public int TimeDeliveryTask;

        public List<OfficeTask> GetBrochure()
        {
            return OfficeTask;
        }
        public OfficeTask TaskServiceOrder(Feedback feedbackTask)
        {
            Console.WriteLine("Task è stato preso in carico");
            DateTime oraPartenzaTask = DateTime.Now;
            feedbackTask("La consegna di task è prevista per le : " + oraPartenzaTask.AddMinutes(1).ToString());
            Thread.Sleep(5000);
            feedbackTask("Task è arrivato a Manager");

            return OfficeTask[0];
        }

    }
}
