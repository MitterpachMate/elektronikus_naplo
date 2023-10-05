namespace elektronikus_naplo
{
    public class ElektronikusNaploDtos
    {
        //Minden tanulot leker
        public record LekerTanulok ( Guid Azon, int Jegy, string Leiras, DateTimeOffset Letrehozas );

        //Letrehoz egy tanulot
        public record LetrehozTanulo ( Guid Azon, int Jegy, string Leiras, DateTimeOffset Letrehozas );

        //Modosit jegyet
        public record ModositJegy (Guid Azon, int Jegy, string Leiras, DateTimeOffset Letrehozas);

        //Jegy torles
        public record TorolJegy(Guid Azon, int Jegy);

    }
}
