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
﻿
