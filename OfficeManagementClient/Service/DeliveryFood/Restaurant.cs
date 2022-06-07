using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.DeliveryFood
{
    public class Restaurant
    {
        public String RestaurantName;
        public RESTAURANTTYPE RestaurantType;
        public int TimeDelivery;
        public List<Food> Food;

        public List<Food> GetMenu()
        {
            return Food;
        }
        public Food Order(Feedback feedback)
        {
            Console.WriteLine("L'ordine è stato preso in carico");
            DateTime oraPartenza = DateTime.Now;
            feedback("la consegna è prevista per le : " + oraPartenza.AddMinutes(1).ToString());
            Thread.Sleep(5000);
            feedback("L'ordine è arrivato a Manager");

            return Food[0];
        }
    }
}
