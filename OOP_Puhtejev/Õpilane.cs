using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace OOP_Puhtejev
{
    public class Õpilane : Isik, ITööline
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public Õppevorm Staatus { get; set; } // Kasutame enumi andmetüübina
        public double Keskminehinne { get; set; }//põhitoetu 60eur
        public int Puudumised { get; set; } = 0;//põhitoetus
        public bool KasOnSotsTõend { get; set; } = false; //eritoetus 120eur

        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk;

        public void Õpi()
        {
            Console.WriteLine($"{Nimi} õpib {Kool} {Klass}. kursuses.");
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpilane {Nimi} ja käin {Klass}. kursuses.");
        }

        public double ArvutaPalk()
        {
            double põhitoetus = 0;
            double eritoetus = 0;
            if (KasOnSotsTõend)
            {
                eritoetus = 120;
            }

            else if (Keskminehinne >= 3.8 && Puudumised <= 30 && KasOnSotsTõend == false)
            {

                eritoetus = 60;
            }
            return põhitoetus + eritoetus;
        }
    }
}
