using System.ComponentModel.DataAnnotations;

namespace WebApiGestioneViaggi.Models.Comunica
{
    public class SaveCityResource
    {
        [Required]
        public long NumeroPositivi { get; set; }

        public City ToCity() => new City()
        {
            NumeroPositivi = this.NumeroPositivi


        };
    }

    public class CreateNewCity
    {
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; }
        public string Area { get; set; }
        public string PosizioneGeografica { get; set; }
        public long NumeroPositivi { get; set; }
        public int CountryId { get; set; }


        public City CreateCity() => new City()
        {
            Nome = this.Nome,
            NumeroAbitanti = this.NumeroAbitanti,
            Area = this.Area,
            PosizioneGeografica = this.PosizioneGeografica,
            NumeroPositivi = this.NumeroPositivi,
            CountryId = this.CountryId
            


        };

    }
}
