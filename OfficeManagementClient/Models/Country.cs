using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public virtual List<City> Cities { get; set; }
        public virtual Continent Continent { get; set; }
    }
}
