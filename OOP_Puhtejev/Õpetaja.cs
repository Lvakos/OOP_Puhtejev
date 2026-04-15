using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Puhtejev
{
    public class Õpetaja : Isik, ITööline
    {
        public string Aine { get; set; }
        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk;
        public double Tunnitasu { get; set; }

        public int TunnidNädalas { get; set; }

        public void Õpeta()
        {
            Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
        }

        public double ArvutaPalk()
        {
            return Tunnitasu * TunnidNädalas * 4;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}. Minu palk on {ArvutaPalk()}.");
        }

    }

    public class Direktor : Isik, ITööline
    {
        public string Aine { get; set; }
        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk;
        public double Tunnitasu { get; set; }
        public int TunnidNädalas { get; set; }
        public double LisaTasu { get; set; }

        public void Õpeta()
        {
            Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
        }

        public double ArvutaPalk()
        {
            return Tunnitasu + * TunnidNädalas * 4;
        }
        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen kooli Direktor {Nimi} ja ma õpetan: {Aine}. Minu palk on {ArvutaPalk()}.");
        }
    }
}
