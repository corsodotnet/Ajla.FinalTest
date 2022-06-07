using OfficeManagementClient.Contratti;
using OfficeManagementClient.Service.DeliveryFood;
using OfficeManagementClient.Service.DeliveryTask;
using OfficeManagementClient.Service.ViaggiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Implementation
{
    public class ManagerOffice : Employee
    {
        TranslationOffice translationOffice = new TranslationOffice();
        FoodDelivery foodDelivery = new FoodDelivery();
        Restaurant restaurant;


        TaskDelivery taskDelivery = new TaskDelivery();
        TaskService taskService;
        public string StartTranslation(LANGUAGE lang, string text)
        {
            return translationOffice.Translate(lang, text);

        }
        public ManagerOffice()
        {
            feedback = GetFeedback;
        }
        public Food StartOrdine(FOOD ordine, Feedback feedbackLawyer)
        {
            Restaurant r = foodDelivery.GetNameRestaurants(ordine);
            Food food = foodDelivery.DeliveryOrder(r, feedback);
            feedbackLawyer(food.FoodName + " è arrivato");
            return food;
        }
        public OfficeTask StartOrdineTask(DOCUMENTO documento, Feedback feedbackTaskLawyer)

        {
            taskService = taskDelivery.GetTaskService(documento);
            OfficeTask officeTask = taskDelivery.TaskOrder(taskService, feedback);
            feedbackTaskLawyer("Il task " + officeTask.TaskName + " è arrivato");
            return officeTask;

        }


        public void CercaViaggio(string paese, Feedback feedback)
        {
           RestrizioneCovid.RunAsync(paese, feedback).GetAwaiter().GetResult();
        }






    }
}
