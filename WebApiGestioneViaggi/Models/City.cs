using WebApiGestioneViaggi.Contracts;

namespace WebApiGestioneViaggi.Models
{
    public class City : IAreaGeografica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
            CountryId = this.CountryId;

        }
    }
}
