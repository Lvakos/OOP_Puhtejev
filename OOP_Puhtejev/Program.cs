using System.Numerics;
using System.IO;

namespace OOP_Puhtejev
{
    internal class Program
    {


        public class Koolihaldus
        {
            // Kapseldatud list
            public List<Isik> inimesed = new List<Isik>();

            public void LisaInimene(Isik isik)
            {
                inimesed.Add(isik);
            }

            public void KuvaKõik()
            {
                Console.WriteLine("\n--- KOOLI NIMEKIRI ---");
                foreach (var isik in inimesed)
                {
                    // Polümorfism teeb siin imesid! 
                    // C# teab ise, kas käivitada Õpetaja või Õpilase Kirjelda() meetod.
                    Console.WriteLine(isik.Kirjelda());
                }
            }

            public void LisaInimene(List<Isik> uuedInimesed)
            {
                inimesed.AddRange(uuedInimesed);
            }

            public void Otsi(string otsitavNimi)
            {
                Console.WriteLine($"\nOtsime nime: {otsitavNimi}");
                foreach (var isik in inimesed)
                {
                    if (isik.Nimi.Contains(otsitavNimi)) Console.WriteLine(isik.Kirjelda());
                }
            }

            public void Otsi(int sünniaasta)
            {
                Console.WriteLine($"\nOtsime kedagi, kellel tunnitasu on: {sünniaasta}");
                // Siin eeldame, et lisasime Isik klassile ka Sünniaasta tagasi
                foreach (var isik in inimesed)
                {
                    if (isik.Sünniaasta == (sünniaasta)) Console.WriteLine(isik.Kirjelda());
                }
            }

            public void SalvestaFaili(string failinimi)
                {
                    using (StreamWriter writer = new StreamWriter(failinimi))
                    {
                        foreach (var isik in inimesed)
                        {
                            writer.WriteLine(isik.Kirjelda());
                        }
                    }
                }

            }

        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inimesed.txt");

            Console.WriteLine("{==== Õpetajad ====}");
            Õpetaja õpetaja1 = new Õpetaja();
            õpetaja1.Nimi = "Marina";
            õpetaja1.Sünniaasta = 1995;
            õpetaja1.Tunnitasu = 13.8;
            õpetaja1.TunnidNädalas = 30;
            õpetaja1.Aine = "programmeerimine";

            Õpetaja irina = new Õpetaja("Irina", "Programmeerimine", 2000);


            Õpilane õpilane1 = new Õpilane();
            õpilane1.Nimi = "Maksimilian";
            õpilane1.Sünniaasta = 2009;
            õpilane1.Kool = "TTHK";
            õpilane1.Klass = 1;
            õpilane1.Puudumised = 21;
            õpilane1.Keskminehinne = 4;
            õpilane1.KasOnSotsTõend = false;

            Õpilane olga = new Õpilane("Olga", "TTHK", 9, 2009);

            Console.WriteLine($"Toetus on: {õpilane1.ArvutaPalk()} eur.");
            List<ITööline> palgasaajad = new List<ITööline>();
            Koolihaldus minuKool = new Koolihaldus();
            minuKool.LisaInimene(olga);
            minuKool.LisaInimene(irina);

            while (true)
            {
                Console.WriteLine("\n--- KOOLI PROGRAMM ---");
                Random rnd = new Random();
                Õppevorm[] vormid = (Õppevorm[])Enum.GetValues(typeof(Õppevorm));
                Console.WriteLine("Kes sa oled, õpetaja, õpilane või direktor? / Kui tahate vaada palga, kirjuta (vaata palga) / Kui tahate vaata kõik inimesed koolimaja, kirjuta (koolimaja)");
                string valik = Console.ReadLine();

                try
                {
                    if (valik.ToLower() == "õpetaja")
                    {
                        Õpetaja õpetaja2 = new Õpetaja();

                        Console.WriteLine("Sinu nimi?: ");
                        õpetaja2.Nimi = Console.ReadLine();

                        Console.WriteLine("Sünniaasta?: ");
                        õpetaja2.Sünniaasta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Tunnitasu? (nt 13.8): ");
                        õpetaja2.Tunnitasu = double.Parse(Console.ReadLine());

                        Console.WriteLine("Tunnid nädalas?: (nt 30)");
                        õpetaja2.TunnidNädalas = int.Parse(Console.ReadLine());

                        Console.WriteLine("Aine?: ");
                        õpetaja2.Aine = Console.ReadLine();

                        palgasaajad.Add(õpetaja2);
                        minuKool.LisaInimene(õpetaja2);
                    }

                    else if (valik.ToLower() == "direktor")
                    {
                        Direktor direktor = new Direktor();

                        Console.WriteLine("Sinu nimi?: ");
                        direktor.Nimi = Console.ReadLine();

                        Console.WriteLine("Sünniaasta?: ");
                        direktor.Sünniaasta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Tunnitasu? (nt 13.8): ");
                        direktor.Tunnitasu = double.Parse(Console.ReadLine());

                        Console.WriteLine("Tunnid nädalas?: (nt 30)");
                        direktor.TunnidNädalas = int.Parse(Console.ReadLine());

                        Console.WriteLine("LisaTasu?: ");
                        direktor.LisaTasu = double.Parse(Console.ReadLine());

                        palgasaajad.Add(direktor);
                        minuKool.LisaInimene(direktor);
                    }

                    else if (valik.ToLower() == "õpilane")
                    {
                        Õpilane õpilane2 = new Õpilane();

                        Console.WriteLine("Sinu nimi?: ");
                        õpilane2.Nimi = Console.ReadLine();

                        Console.WriteLine("Sünniaasta?: ");
                        õpilane2.Sünniaasta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Kus sa õpid?: ");
                        õpilane2.Kool = Console.ReadLine();

                        Console.WriteLine("Millises kursuses sa õpid? (nt 1): ");
                        õpilane2.Klass = int.Parse(Console.ReadLine());

                        Console.WriteLine("Kui palju puudumised sul on?: ");
                        õpilane2.Puudumised = int.Parse(Console.ReadLine());

                        Console.WriteLine("Sinu Keskminehinne?: ");
                        õpilane2.Keskminehinne = double.Parse(Console.ReadLine());

                        õpilane2.Staatus = vormid[rnd.Next(1, 4)];

                        Console.WriteLine("Kas sulle on vaja sotsiaalne tõend? (eritoetus) jah/ei: ");
                        string eritoetusValik = Console.ReadLine();
                        if (eritoetusValik.ToLower() == "jah")
                            õpilane2.KasOnSotsTõend = true;

                        palgasaajad.Add(õpilane2);
                        minuKool.LisaInimene(õpilane2);
                    }

                    else if (valik.ToLower() == "vaata palga")
                    {
                        foreach (ITööline isik in palgasaajad)
                        {
                            string tüüp = isik.VäljamakseTüüp.ToString().ToLower();
                            Console.WriteLine($"{tüüp} summa: {isik.ArvutaPalk()} eurot. {((Isik)isik).Nimi}");
                        }
                    }

                    else if (valik.ToLower() == "koolimaja")
                    {
                        Console.WriteLine($"Kõik inimeste arv: {Isik.InimesteKoguarv}");
                        minuKool.KuvaKõik();
                    }

                    else if (valik.ToLower() == "otsi")
                    {
                        Console.WriteLine("Kirjuta sünniaasta või nimi: ");
                        string Andmed = Console.ReadLine();
                        if (int.TryParse(Andmed, out int sünniaasta))
                        {
                            minuKool.Otsi(sünniaasta);
                        }
                        else
                        {
                            minuKool.Otsi(Andmed);
                        }
                    }

                    else if (valik.ToLower() == "salvesta faili")
                    {
                        minuKool.SalvestaFaili(path);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
