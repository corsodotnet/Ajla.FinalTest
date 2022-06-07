namespace WebApiGestioneViaggi.Contracts
{
    public interface IAreaGeografica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long NumeroAbitanti { get; set; } 
        public string Area { get; set; } 
        public string PosizioneGeografica { get; set; } 
        public long NumeroPositivi { get; set; } 
    }
}
