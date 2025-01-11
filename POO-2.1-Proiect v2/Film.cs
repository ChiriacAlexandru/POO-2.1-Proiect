public class Film
{
    public int Id;
    public string Nume;
    public DateTime DataStart;
    public DateTime DataSfarsit;
    public int SalaId;
    public Film(int id, string nume, DateTime dataStart, DateTime dataSfarsit, int salaId)
    {
        Id = id;
        Nume = nume;
        DataStart = dataStart;
        DataSfarsit = dataSfarsit;
        SalaId = salaId;
    }
}