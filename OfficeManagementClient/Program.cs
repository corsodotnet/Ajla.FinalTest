using OfficeManagementClient.Implementation;
using OfficeManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OfficeManagementClient
{
    public class Program
    {
       
        static async Task Main()
        {
            Lawyer lawyer = new Lawyer();
            lawyer.Viaggia("Italia");
            lawyer.OrdinaTraduzione(LANGUAGE.ENG, "HI");
            lawyer.OrdinazioneCibo(FOOD.PIZZA);
            //lawyer.OrdinaTaskUfficio(DOCUMENTO.MODULO);
           

        }


    }

    public enum LANGUAGE
    {
        ENG,
        GERMAN,
        SPANISH

    }
    public enum RESTAURANTTYPE
    {
        BREAKFAST,
        LUNCH,
        DINNER



    }
    public enum FOOD
    {
        CAFFE,
        PANINO,
        PIZZA
    }

    public enum DOCUMENTO
    {
        MODULO,
        PRATICA
    }
    public enum TASKTYPE
    {
        LEGALE,
        FISCALE
    }
}
