using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cinema = new Cinema();
            string saliFisier = "sali.txt";
            string filmeFisier = "filme.txt";
            string utilizatoriFisier = "utilizatori.txt";

            cinema.IncarcaSali(saliFisier);
            cinema.IncarcaFilme(filmeFisier);

            var utilizatori = File.Exists(utilizatoriFisier)
                ? File.ReadAllLines(utilizatoriFisier).Select(Utilizator.FromString).ToList()
                : new List<Utilizator>();

            Utilizator utilizatorCurent = null;

            Console.WriteLine("Bine ai venit la CinemaApp");
            Console.WriteLine("Alege o optiune:");
            Console.WriteLine("1.Inregistrare:");
            Console.WriteLine("2.Logare:");
            string optinueInregistrareLogare = Console.ReadLine();
            switch (optinueInregistrareLogare)
            {
                case "1":
                    Console.WriteLine("Introduceti numele:");
                    string nume = Console.ReadLine();
                    Console.WriteLine("Introduceti prenumele:");
                    string prenume = Console.ReadLine();
                    Console.WriteLine("Introduceti email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Introduceti parola:");
                    string parola = Console.ReadLine();
                    Console.WriteLine("Introduceti daca este admin sau nu:");
                    bool isAdmin = Console.ReadLine().ToLower() == "da";
                    utilizatorCurent = new Utilizator(nume, prenume, email, parola, isAdmin);
                    utilizatori.Add(utilizatorCurent);
                    File.WriteAllLines(utilizatoriFisier, utilizatori.Select(u => u.ToString()));
                    Console.WriteLine("Inregistrare cu succes!Te poti loga acum");
                    break;
                case "2":
                    Console.WriteLine("Introduceti email:");
                    string emailLogare = Console.ReadLine();
                    Console.WriteLine("Introduceti parola:");
                    string parolaLogare = Console.ReadLine();
                    utilizatorCurent = utilizatori.FirstOrDefault(u => u.Email == emailLogare && u.Parola == parolaLogare);
                    if (utilizatorCurent != null)
                    {
                        Console.WriteLine("Logare cu succes!");
                    }
                    else
                    {
                        Console.WriteLine("Email sau parola gresite!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Optiune invalida!");
                    return;
            }
        }
    }
}