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
       
    }
}
