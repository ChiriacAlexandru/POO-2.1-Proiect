
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

}