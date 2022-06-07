using OfficeManagementClient.Contratti;
using OfficeManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OfficeManagementClient.Service.ViaggiService
{
    public class RestrizioneCovid
    {
        static HttpClient client = new HttpClient();



        static async Task<Country> GetCountryByNameAsync(string Name)
        {
            Country country = null;
            HttpResponseMessage response = await client.GetAsync($"/api/AreaGeografica/CountryName/{Name}");
            if (response.IsSuccessStatusCode)
            {
                country = await response.Content.ReadAsAsync<Country>();
            }
            return country;
        }
        static async Task<City> GetCityByNameAsync(string Name)
        {
            City city = null;
            HttpResponseMessage response = await client.GetAsync($"/api/AreaGeografica/CityName/{Name}");
            if (response.IsSuccessStatusCode)
            {
                city = await response.Content.ReadAsAsync<City>();
            }
            return city;
        }

        public static async Task RunAsync(string paese, Feedback feedback)
        {
            Country ctr = null;
            City city = null;
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                ctr = await GetCountryByNameAsync(paese);
               // city = await GetCityByNameAsync("Milano");
                feedback("Il paese in che vuoi viaggare è in zona: " + ctr.Area + "Numero di positivi è: " + ctr.NumeroPositivi);
               // Console.WriteLine(city.NumeroPositivi);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
