using OfficeManagementClient.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.DeliveryFood
{
    public class FoodDelivery
    {
        public List<Restaurant> Restaurants;
        // public FactoryFood factoryFood;

        public FoodDelivery()
        {
            Restaurants = new List<Restaurant>();
            AddRestaurants();
        }
        public void AddRestaurants()
        {
            Restaurant restaurant1 = new Restaurant();
            Restaurant restaurant2 = new Restaurant();
            Restaurant restaurant3 = new Restaurant();

            restaurant1.RestaurantName = "Starbucks";
            restaurant1.RestaurantType = RESTAURANTTYPE.BREAKFAST;
            restaurant1.Food = new List<Food> { new Food("CAFFE") };
            restaurant1.TimeDelivery = 10;

            restaurant2.RestaurantName = "McDonald";
            restaurant2.RestaurantType = RESTAURANTTYPE.LUNCH;
            restaurant2.Food = new List<Food> { new Food("PANINO") };
            restaurant2.TimeDelivery = 15;


            restaurant3.RestaurantName = "Dominos";
            restaurant3.RestaurantType = RESTAURANTTYPE.DINNER;
            restaurant3.Food = new List<Food> { new Food("PIZZA") };
            restaurant3.TimeDelivery = 17;


            Restaurants.Add(restaurant1);
            Restaurants.Add(restaurant2);
            Restaurants.Add(restaurant3);
        }
        public Restaurant GetNameRestaurants(FOOD ordine)
        {
            RESTAURANTTYPE type;

            type = GetType(ordine);
            switch (type)
            {
                case RESTAURANTTYPE.BREAKFAST:
                    var result = Restaurants.Where(x => x.RestaurantType == RESTAURANTTYPE.BREAKFAST).ToList();
                    var min = result.Min(x => x.TimeDelivery);
                    List<Restaurant> restaurant = result.Where(x => x.TimeDelivery == min).ToList();
                    return restaurant.FirstOrDefault();

                    break;
                case RESTAURANTTYPE.LUNCH:
                    var result1 = Restaurants.Where(x => x.RestaurantType == RESTAURANTTYPE.LUNCH).ToList();
                    var min1 = result1.Min(x => x.TimeDelivery);
                    List<Restaurant> restaurant1 = result1.Where(x => x.TimeDelivery == min1).ToList();
                    return restaurant1.FirstOrDefault();
                    break;
                case RESTAURANTTYPE.DINNER:
                    var result2 = Restaurants.Where(x => x.RestaurantType == RESTAURANTTYPE.DINNER).ToList();
                    var min2 = result2.Min(x => x.TimeDelivery);
                    List<Restaurant> restaurant2 = result2.Where(x => x.TimeDelivery == min2).ToList();
                    return restaurant2.FirstOrDefault();
                    break;
                default:
                    return null;
                    break;
            }
            // var tempoMin1 = Restaurants.Min(x => x.TimeDelivery);




        }
        public RESTAURANTTYPE GetType(FOOD ordine)
        {
            switch (ordine)
            {
                case FOOD.CAFFE:
                    return RESTAURANTTYPE.BREAKFAST;
                    break;
                case FOOD.PANINO:
                    return RESTAURANTTYPE.LUNCH;
                    break;
                case FOOD.PIZZA:
                    return RESTAURANTTYPE.DINNER;
                    break;
                default:
                    return RESTAURANTTYPE.DINNER;
                    Console.WriteLine("ORDINE NON TROVATO");
            }
        }
        public Food DeliveryOrder(Restaurant restaurant, Feedback feedback)
        {
            return restaurant.Order(feedback);
        }
    }
}
