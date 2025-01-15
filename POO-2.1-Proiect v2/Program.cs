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
                        if (utilizatorCurent.IsAdmin)
            {
                AdminMenu(cinema, saliFisier, filmeFisier, utilizatoriFisier, utilizatorCurent);
            }
            else
            {
                ClientMenu(cinema, utilizatorCurent);
            }
        }

        static void AdminMenu(Cinema cinema, string saliFisier, string filmeFisier, string utilizatoriFisier, Utilizator admin)
        {
            while (true)
            {
                Console.WriteLine("\n--- Panou Admin ---");
                Console.WriteLine("1. Adaugă sală");
                Console.WriteLine("2. Adaugă film");
                Console.WriteLine("3. Vizualizează filme disponibile");
                Console.WriteLine("4. Vizualizează rezervări");
                Console.WriteLine("5. Șterge rezervare");
                Console.WriteLine("6. Ieșire");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("ID sală: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Capacitate: ");
                        int capacitate = int.Parse(Console.ReadLine());
                        cinema.Sali.Add(new Sala(id, capacitate));
                        cinema.SalveazaSali(saliFisier);
                        Console.WriteLine("Sală adăugată cu succes.");
                        break;

                    case "2":
                        Console.Write("Nume film: ");
                        string nume = Console.ReadLine();
                        Console.Write("Data start (yyyy-MM-dd HH:mm): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.Write("Data end (yyyy-MM-dd HH:mm): ");
                        DateTime end = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Săli disponibile:");
                        foreach (var sala in cinema.Sali)
                        {
                            Console.WriteLine($"ID: {sala.Id}, Capacitate: {sala.Capacitate}");
                        }

                        Console.Write("Alege ID sală: ");
                        int salaId = int.Parse(Console.ReadLine());

                        try
                        {
                            cinema.AdaugaFilm(new Film(cinema.Filme.Count + 1, nume, start, end, salaId));
                            cinema.SalveazaFilme(filmeFisier);
                            Console.WriteLine("Film adăugat cu succes.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Eroare: {ex.Message}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nFilmele disponibile:");
                        foreach (var film in cinema.Filme)
                        {
                            Console.WriteLine(film.ToString());
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nRezervările existente:");
                        foreach (var rezervare in cinema.Rezervari)
                        {
                            Console.WriteLine(rezervare.ToString());
                        }
                        break;

                    case "5":
                        Console.Write("Introduceti ID-ul rezervarii de șters: ");
                        int rezervareId = int.Parse(Console.ReadLine());
                        var rezervareDeSters = cinema.Rezervari.FirstOrDefault(r => r.FilmId == rezervareId);
                        if (rezervareDeSters != null)
                        {
                            cinema.Rezervari.Remove(rezervareDeSters);
                            Console.WriteLine("Rezervare ștearsă cu succes.");
                        }
                        else
                        {
                            Console.WriteLine("Rezervarea nu a fost găsită.");
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Opțiune invalidă.");
                        break;
                }
            }
        }

        static void ClientMenu(Cinema cinema, Utilizator client)
        {
            while (true)
            {
                Console.WriteLine("\n--- Meniu Client ---");
                Console.WriteLine("1. Vizualizează filme disponibile");
                Console.WriteLine("2. Rezervă locuri");
                Console.WriteLine("3. Ieșire");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.WriteLine("\nFilmele disponibile:");
                        foreach (var film in cinema.Filme)
                        {
                            Console.WriteLine(film.ToString());
                        }
                        break;

                    case "2":
                        Console.Write("Introduceti ID film: ");
                        int filmId = int.Parse(Console.ReadLine());
                        Console.Write("Numar locuri: ");
                        int locuri = int.Parse(Console.ReadLine());

                        try
                        {
                            cinema.AdaugaRezervare(new Rezervare(filmId, client.Nume, locuri));
                            Console.WriteLine("Rezervare realizată cu succes.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Eroare: {ex.Message}");
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Opțiune invalidă.");
                        break;
                }
            }
        }
    }
}

        }
    }
}
