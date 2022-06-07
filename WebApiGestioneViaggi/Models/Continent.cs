using System.Collections.Generic;
using System.Linq;
using WebApiGestioneViaggi.Contracts;

namespace WebApiGestioneViaggi.Models
{
    public class Continent : IAreaGeografica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public virtual List<Country> Countries { get; set; }

        public static long NumeroPositiviContinent(List<Country> counties)
        {
            long total = counties.Sum(item => item.NumeroPositivi);
            return total;
        }
    }
}
