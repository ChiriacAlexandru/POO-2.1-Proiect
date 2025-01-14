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
    public override string ToString()
    {
        return $"{Id},{Nume},{DataStart},{DataSfarsit},{SalaId}";
    }
    public static Film FromString(string line)
    {
        var parts = line.Split(',');
        return new Film(int.Parse(parts[0]), parts[1], DateTime.Parse(parts[2]), DateTime.Parse(parts[3]), int.Parse(parts[4]));
    }
}