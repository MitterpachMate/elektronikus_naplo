namespace elektronikus_naplo.Models
{
    public class TanuloOsztaly
    {
        public Guid Azon {  get; set; }
        public int Jegy { get; set; }
        public required string Leiras { get; set; }
        public DateTimeOffset Letrehozas { get; set; }
    }
}  

