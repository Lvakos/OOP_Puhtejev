using System;

namespace OOP_Puhtejev
{
    public class Üliõpilane : Õpilane
    {
        public string Eriala { get; set; }

        public override string Kirjelda()
        {
            return $"Mina olen üliõpilane {Nimi}, õpin {Klass}. kursusel, õppevorm on {Staatus} ja eriala on {Eriala}.";
        }
    }
}