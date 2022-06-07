using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.DeliveryTask
{
    public class TaskDelivery
    {
        public List<TaskService> taskServices = new List<TaskService>();
        public TaskDelivery()
        {
            AddTaskServices();
        }

        public void AddTaskServices()
        {
            TaskService taskService1 = new TaskService();
            TaskService taskService2 = new TaskService();

            taskService1.TaskServiceType = TASKTYPE.FISCALE;
            taskService1.TaskServiceName = "CAF CGN";
            taskService1.OfficeTask = new List<OfficeTask> { new OfficeTask("MODULO") };
            taskService1.TimeDeliveryTask = 10;

            taskService2.TaskServiceType = TASKTYPE.LEGALE;
            taskService2.TaskServiceName = "STUDIO LEGALE";
            taskService2.OfficeTask = new List<OfficeTask> { new OfficeTask("PRATICA") };
            taskService2.TimeDeliveryTask = 20;

            taskServices.Add(taskService1);
            taskServices.Add(taskService2);

        }

        public TaskService GetTaskService(DOCUMENTO documento)
        {
            TASKTYPE taskType;

            taskType = GetType(documento);
            switch (taskType)
            {
                case TASKTYPE.FISCALE:
                    var result = taskServices.Where(x => x.TaskServiceType == TASKTYPE.FISCALE).ToList();
                    var min = result.Min(x => x.TimeDeliveryTask);
                    List<TaskService> service = result.Where(x => x.TimeDeliveryTask == min).ToList();
                    return service.FirstOrDefault();

                    break;
                case TASKTYPE.LEGALE:
                    var result1 = taskServices.Where(x => x.TaskServiceType == TASKTYPE.LEGALE).ToList();
                    var min1 = result1.Min(x => x.TimeDeliveryTask);
                    List<TaskService> service1 = result1.Where(x => x.TimeDeliveryTask == min1).ToList();
                    return service1.FirstOrDefault();
                    break;
                default:
                    return null;
                    break;
            }

        }

        public TASKTYPE GetType(DOCUMENTO documento)
        {
            switch (documento)
            {
                case DOCUMENTO.MODULO:
                    return TASKTYPE.FISCALE;
                    break;
                case DOCUMENTO.PRATICA:
                    return TASKTYPE.LEGALE;
                    break;
                default:
                    return TASKTYPE.LEGALE;
                    Console.WriteLine("TASK NON TROVATO");
            }
        }
        public OfficeTask TaskOrder(TaskService taskService, Feedback feedbackTask)
        {
            return taskService.TaskServiceOrder(feedbackTask);
        }

    }
}
