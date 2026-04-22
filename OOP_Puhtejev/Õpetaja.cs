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

        public override string Kirjelda()
        {
            return $"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}. Minu palk on {ArvutaPalk()}.";
        }

        public Õpetaja() : base() // kutsume baasklassi konstruktorit
        {
            // Siin saame teha täiendavaid initsialiseerimisi, kui vaja
        }

        public Õpetaja(string nimi, string aine, int sünniaasta) : base(nimi, sünniaasta) // Kutsume baasklassi
        {
            Nimi = nimi;
            Aine = aine;
            Sünniaasta = sünniaasta;
        }
    }

    public class Direktor : Isik, ITööline
    {
        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk;
        public double Tunnitasu { get; set; }
        public int TunnidNädalas { get; set; }
        public double LisaTasu { get; set; }
        public double ArvutaPalk()
        {
            return (Tunnitasu + LisaTasu) * TunnidNädalas * 4;
        }
        public override string Kirjelda()
        {
            return $"Mina olen kooli Direktor {Nimi}. Minu palk on {ArvutaPalk()}.";
        }
    }
}
