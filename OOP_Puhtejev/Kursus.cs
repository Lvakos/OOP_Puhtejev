using System;

namespace OOP_Puhtejev
{
    public class Kursus
    {
        public string Nimi { get; set; }
        public Õpetaja VastutavÕpetaja { get; set; }

        public void KuvaInfo()
        {
            Console.WriteLine($"Kursus: {Nimi}, Vastutav õpetaja: {VastutavÕpetaja.Nimi}");
        }
    }
}