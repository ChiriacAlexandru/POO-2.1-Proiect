public class Rezervare
{
    public int FilmId;
    public string NumeClient;
    public int NumarLocuri;
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