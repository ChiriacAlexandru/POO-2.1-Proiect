using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2._1_Proiect_v2
{
    public class Sala
    {
        public int Id { get; set; }
        public int Capacitate { get; set; }
        public Sala(int id, int capacitate)
        {
            Id = id;
            Capacitate = capacitate;
        }

        public override string ToString()
        {
            return $"{Id},{Capacitate}";
        }
        public static Sala FromString(string line)
        {
            var parts=line.Split(' ');
            return new Sala(int.Parse(parts[0]),int.Parse(parts[1]));
        }

    }
}
