namespace POO_2._1_Proiect_v2
{
    public class Rezervare
    {
        public int FilmId { get; set; }
        public string NumeClient { get; set; }
        public int NumarLocuri { get; set; }

        public Rezervare(int filmId, string numeClient, int numarLocuri)
        {
            FilmId = filmId;
            NumeClient = numeClient;
            NumarLocuri = numarLocuri;
        }

        public override string ToString()
        {
            return $"{FilmId},{NumeClient},{NumarLocuri}";
        }

        public static Rezervare FromString(string line)
        {
            var parts = line.Split(',');
            return new Rezervare(int.Parse(parts[0]), parts[1], int.Parse(parts[2]));
        }
    }
}
