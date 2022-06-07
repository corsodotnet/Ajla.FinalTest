using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementClient.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public virtual Country Country { get; set; }

    }
}
