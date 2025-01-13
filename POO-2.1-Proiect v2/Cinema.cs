using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2._1_Proiect_v2
{
    public class Cinema
    {
        public List<Sala> Sali { get; private set; } = new List<Sala>();
        public List<Film> Filme { get; private set; } = new List<Film>();
        public List<Rezervare> Rezervari { get; private set; } = new List<Rezervare>();
        public void IncarcaSali(string fisier)
        {
            if (File.Exists(fisier))

                Sali = File.ReadAllLines(fisier).Select(Sala.FromString).ToList();

        }
        public void SalveazaSali(string fisier)
        {
            File.WriteAllLines(fisier, Sali.Select(s => s.ToString()));
        }
        public void AdaugaFilm(Film film)
        {
            if (!Filme.Any(f => f.SalaId == film.SalaId && ((film.DataStart >= f.DataStart && film.DataStart < f.DataSfarsit) || (film.DataSfarsit > f.DataStart && film.DataSfarsit <= f.DataSfarsit))))
            {
                Filme.Add(film);
            }
            else
                throw new Exception("Sala este deja rezervata pentru aceasta perioada.");
        }


        public void AdaugareRezervare(Rezervare rezervare)
        {
            var film = Filme.FirstOrDefault(f => f.Id == rezervare.FilmId);
            if(film != null)
            {
                var sala=Sali.FirstOrDefault(s=>s.Id == film.SalaId);
                if (sala != null)
                {
                    int locuriRezervate = Rezervari.Where(r => r.FilmId == rezervare.FilmId).Sum(r => r.NumarLocuri);
                    if (locuriRezervate + rezervare.NumarLocuri <= sala.Capacitate)
                    {
                        Rezervari.Add(rezervare);
                    }
                    else
                    {
                        throw new Exception("Numarul de locuri rezervate depaseste capacitatea salii.");
                  
                   }
                }
                else 
                {
                   throw new Exception("Sala nu exista.");
                }
            }
            else
            {
                throw new Exception("Filmul nu exista.");
            }
        }

    }
}
