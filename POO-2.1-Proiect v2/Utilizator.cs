namespace POO_2._1_Proiect_v2
{
    public class Utilizator
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public bool IsAdmin { get; set; }

        public Utilizator(string nume, string prenume, string email, string parola, bool isAdmin)
        {
            Nume = nume;
            Prenume = prenume;
            Email = email;
            Parola = parola;
            IsAdmin = isAdmin;
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
}
