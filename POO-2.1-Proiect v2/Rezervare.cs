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
}