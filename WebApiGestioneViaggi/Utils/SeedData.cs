using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGestioneViaggi.Models;
using WebApiGestioneViaggi.Persistence;

namespace WebApiGestioneViaggi.Utils
{
    public static class SeedData
    {

        public static async Task SeedDatabase(DatabaseCxt dbCtx)
        {

            //using (dbCtx)
            //{
            //    Clear(dbCtx.Continent);
            //    Clear(dbCtx.Country);
            //    Clear(dbCtx.City);
            //    dbCtx.SaveChanges();

            //}



            List<City> citiesItalia = new List<City>()
            {
                new City() { Nome = "Milano", NumeroAbitanti = 1371606, Area ="" , PosizioneGeografica = "", NumeroPositivi = 50000},
                new City() { Nome = "Roma", NumeroAbitanti = 2758454, Area ="" , PosizioneGeografica = "", NumeroPositivi = 45000},
                new City() { Nome = "Padova", NumeroAbitanti = 208561, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000},
                new City() { Nome = "Firenze", NumeroAbitanti = 367825, Area ="" , PosizioneGeografica = "", NumeroPositivi = 3000 }
            };
            List<City> citiesSpagna = new List<City>()
            {
                new City() { Nome = "Madrid", NumeroAbitanti = 3165541, Area ="" , PosizioneGeografica = "", NumeroPositivi = 500020},
                new City() { Nome = "Barcellona", NumeroAbitanti = 1608746, Area ="" , PosizioneGeografica = "", NumeroPositivi = 400000},
                new City() { Nome = "Valencia", NumeroAbitanti = 790201, Area ="" , PosizioneGeografica = "", NumeroPositivi = 4000},
                new City() { Nome = "Siviglia", NumeroAbitanti = 690566, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000}
            }; 
            List<City> citiesSlovenia = new List<City>()
            {
                new City() { Nome = "Lubiana", NumeroAbitanti = 284355, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000},
                new City() { Nome = "Maribor", NumeroAbitanti = 95767, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000},
                new City() { Nome = "Celie", NumeroAbitanti = 37875, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000},
                new City() { Nome = "Kranj", NumeroAbitanti = 37463, Area ="" , PosizioneGeografica = "", NumeroPositivi = 10000 }
            }; 
            List<City> citiesBosnia = new List<City>()
            {
                new City() { Nome = "Tuzla", NumeroAbitanti = 445028, Area ="" , PosizioneGeografica = "", NumeroPositivi = 500},
                new City() { Nome = "Srajevo", NumeroAbitanti = 275524, Area ="" , PosizioneGeografica = "", NumeroPositivi = 300},
                new City() { Nome = "Travnik", NumeroAbitanti = 57000, Area ="" , PosizioneGeografica = "", NumeroPositivi = 500},
                new City() { Nome = "Mostar", NumeroAbitanti = 105797, Area ="" , PosizioneGeografica = "", NumeroPositivi = 800 }
            };




            List<Country> countries = new List<Country>()
            {
                new Country() { Nome = "Italia", NumeroAbitanti = 28000000, Area ="", PosizioneGeografica = "", NumeroPositivi = Country.NumeroPositiviCountry(citiesItalia),Cities = citiesItalia},
                new Country() { Nome = "Spagna", NumeroAbitanti = 46769864, Area ="" , PosizioneGeografica = "", NumeroPositivi = Country.NumeroPositiviCountry(citiesSpagna),Cities = citiesSpagna},
                new Country() { Nome = "Slovenia", NumeroAbitanti = 2111461, Area ="" , PosizioneGeografica = "", NumeroPositivi = Country.NumeroPositiviCountry(citiesSlovenia),Cities = citiesSlovenia},
                new Country() { Nome = "Bosnia", NumeroAbitanti = 3290791, Area ="" , PosizioneGeografica = "", NumeroPositivi = Country.NumeroPositiviCountry(citiesBosnia),Cities = citiesBosnia }
            };
           
            countries[0].ColoreZona();
            countries[1].ColoreZona();
            countries[2].ColoreZona();
            countries[3].ColoreZona();

            Continent continent1 = new Continent()
            {
                Nome = "Europa",
                NumeroAbitanti = 748323400,
                Area = "",
                PosizioneGeografica = "",
                NumeroPositivi = Continent.NumeroPositiviContinent(countries),
                Countries = countries



            };


            dbCtx.Continent.Add(continent1);

          

            try
            {
                await dbCtx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
            }
        }
    }

    public enum COLOREZONA
    { 
        RED,
        ORANGE,
        YELLOW,
        WHITE

    }
}
