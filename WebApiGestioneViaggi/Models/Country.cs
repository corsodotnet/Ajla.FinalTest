using System.Collections.Generic;
using System.Linq;
using WebApiGestioneViaggi.Contracts;

namespace WebApiGestioneViaggi.Models
{
    public class Country : IAreaGeografica
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public int ContinentId { get; set; }

        public virtual List<City> Cities { get; set; }
       public virtual Continent Continent { get; set; }

        public static long NumeroPositiviCountry(List<City> cities)
        {
            long total = cities.Sum(item => item.NumeroPositivi);
            return total;
        }
  

        public void ColoreZona()
        {
            if (NumeroPositivi > 500000)
            {
                Area = "Red";
            }

            if (NumeroPositivi > 100000 && NumeroPositivi <= 500000)
            {
                Area = "Orange";
            }

            if (NumeroPositivi > 10000 && NumeroPositivi <= 100000)
            {
                Area = "Yellow";
            }

            if (NumeroPositivi <= 10000)
            {
                Area = "White";
            }
           
           
            
        }
    }
}


