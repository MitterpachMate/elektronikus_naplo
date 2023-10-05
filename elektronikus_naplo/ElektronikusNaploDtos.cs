using System.ComponentModel.DataAnnotations;

namespace elektronikus_naplo
{
    public class ElektronikusNaploDtos
    {
        //Minden Tanulo jegy megjelenit
        public record TanuloDto(Guid Azon, int Jegy, string Leiras, DateTimeOffset Letrehozas);

        //Minden Jegy hozzaad
        public record JegyHozzaad(Guid Azon, int Jegy, string Leiras, DateTimeOffset Letrehozas);

            //Tanulo jegy modosit
            public record JegyModosit(Guid Azon, [Range(1, 5)] int Jegy, string Leiras);
            
            //Tanulo jegy torol
            public record JegyTorol(Guid Azon);
    }
}
