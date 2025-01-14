
public class Utilizator
{
    public string Nume;
    public string Prenume;
    public string Email;
    public string Parola;
    public bool IsAdmin;
    public Utilizator(string nume, string prenume, string email,string parola,bool isAdmin)
    {
        Nume= nume;
        Prenume= prenume;
        Email= email;
        Parola = parola;
        IsAdmin= isAdmin;

    }
    public override string ToString()
    {
        return $"{Nume},{Prenume},{Email},{Parola},{IsAdmin}";
    }
    public static Utilizator FromString(string line)
    {
        var parts = line.Split(',');
        return new Utilizator(parts[0], parts[1], parts[2], parts[3], bool.Parse(parts[4]));
    }

}