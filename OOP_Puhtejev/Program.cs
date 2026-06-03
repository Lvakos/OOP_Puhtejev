using System.Globalization;
using System.IO;
using System.Numerics;

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

            // 1. Otsing nime järgi (võtab vastu stringi)
            public void Otsi(string otsitavNimi)
            {
                Console.WriteLine($"\nOtsime nime: {otsitavNimi}");
                foreach (var isik in inimesed)
                {
                    if (isik.Nimi.Contains(otsitavNimi)) Console.WriteLine(isik.Kirjelda());
                }
            }

            // 2. Otsing nimekirjas numbri/sünniaasta järgi (sama nimi, aga võtab vastu int)
            public void Otsi(int sünniaasta)
            {
                Console.WriteLine($"\nOtsime kedagi, kellel tunnitasu on: {sünniaasta}");
                // Siin eeldame, et lisasime Isik klassile ka Sünniaasta tagasi
                foreach (var isik in inimesed)
                {
                    if (isik.Sünniaasta == (sünniaasta)) Console.WriteLine(isik.Kirjelda());
                }
            }

            // 3. Salvesta kõik failis
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

            // 4. Kuva ainult õpilased
            public void KuvaAinultÕpilased()
            {
                Console.WriteLine("--- AINULT ÕPILASED ---");
                foreach (var õpilane in inimesed.OfType<Õpilane>().ToList())
                {
                    Console.WriteLine(õpilane.Kirjelda());
                }

            }

        }

        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inimesed.txt");

            // Inimese lisamine
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

            Üliõpilane üliõpilane1 = new Üliõpilane();

            üliõpilane1.Nimi = "Karl";
            üliõpilane1.Sünniaasta = 2003;
            üliõpilane1.Kool = "TalTech";
            üliõpilane1.Klass = 2;
            üliõpilane1.Staatus = Õppevorm.Päevane;
            üliõpilane1.Eriala = "Informaatika";

            Õpilane olga = new Õpilane("Olga", "TTHK", 9, 2009);

            Console.WriteLine($"Toetus on: {õpilane1.ArvutaPalk()} eur.");
            List<ITööline> palgasaajad = new List<ITööline>();
            // Lisamine inimese ühe listis
            Koolihaldus minuKool = new Koolihaldus();
            
            minuKool.LisaInimene(olga);
            minuKool.LisaInimene(irina);
            minuKool.LisaInimene(üliõpilane1);

            // Kursuse lisamine
            Kursus programmeerimine = new Kursus { Nimi = "C# algkursus", VastutavÕpetaja = irina };

            programmeerimine.KuvaInfo();

            minuKool.KuvaAinultÕpilased();

            while (true)
            {
                Console.WriteLine("--- KOOLI PROGRAMM ---");
                Random rnd = new Random();
                Õppevorm[] vormid = (Õppevorm[])Enum.GetValues(typeof(Õppevorm));
                Console.WriteLine("""
                    Valikud:
                    1. Õpetaja Lisamine
                    2. Direktori Lisamine
                    3. Õpilane Lisamine
                    4. Vaata palga
                    5. Vaata koguinimeste arv
                    6. Koolimaja inimene otsimine
                    7. Salvesta inimesed failis
                    8. Kuva ainult õpilased
                    9. Loo kursus ja kuva info
                    10. Pane hinne
                    11. Üliõpilane lisamine
                    """);

                try
                {
                    string valik = Console.ReadLine();
                    switch (valik)
                    {
                        case "1":
                            Õpetaja õpetaja2 = new Õpetaja();

                            Console.WriteLine("Sinu nimi?: ");
                            õpetaja2.Nimi = Console.ReadLine();

                            Console.WriteLine("Sünniaasta?: ");
                            int aast = int.Parse(Console.ReadLine());

                            if (aast > 1900 && aast < 2026)
                            {
                                õpetaja2.Sünniaasta = aast;
                            }
                            else
                            {
                                Console.WriteLine("Vigane sünniaasta!");
                                break;
                            }

                            Console.WriteLine("Tunnitasu? (nt 13.8): ");
                            õpetaja2.Tunnitasu = double.Parse(Console.ReadLine());

                            Console.WriteLine("Tunnid nädalas?: (nt 30)");
                            õpetaja2.TunnidNädalas = int.Parse(Console.ReadLine());

                            Console.WriteLine("Aine?: ");
                            õpetaja2.Aine = Console.ReadLine();

                            palgasaajad.Add(õpetaja2);
                            minuKool.LisaInimene(õpetaja2);
                            break;

                        case "2":
                        
                            Direktor direktor = new Direktor();

                            Console.WriteLine("Sinu nimi?: ");
                            direktor.Nimi = Console.ReadLine();

                            Console.WriteLine("Sünniaasta?: ");
                            int aastdir = int.Parse(Console.ReadLine());

                            if (aastdir > 1900 && aastdir < 2026)
                            {
                                direktor.Sünniaasta = aastdir;
                            }
                            else
                            {
                                Console.WriteLine("Vigane sünniaasta!");
                                break;
                            }

                            Console.WriteLine("Tunnitasu? (nt 13.8): ");
                            direktor.Tunnitasu = double.Parse(Console.ReadLine());

                            Console.WriteLine("Tunnid nädalas?: (nt 30)");
                            direktor.TunnidNädalas = int.Parse(Console.ReadLine());

                            Console.WriteLine("LisaTasu?: ");
                            direktor.LisaTasu = double.Parse(Console.ReadLine());

                            palgasaajad.Add(direktor);
                            minuKool.LisaInimene(direktor);
                            break;

                        case "3":
                            Õpilane õpilane2 = new Õpilane();

                            Console.WriteLine("Sinu nimi?: ");
                            õpilane2.Nimi = Console.ReadLine();

                            Console.WriteLine("Sünniaasta?: ");
                            int õpilaneaast = int.Parse(Console.ReadLine());

                            if (õpilaneaast > 1900 && õpilaneaast < 2026)
                            {
                                õpilane2.Sünniaasta = õpilaneaast;
                            }
                            else
                            {
                                Console.WriteLine("Vigane sünniaasta!");
                                break;
                            }

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
                            break;

                        case "4":
                            foreach (ITööline isik in palgasaajad)
                            {
                                string tüüp = isik.VäljamakseTüüp.ToString().ToLower();
                                Console.WriteLine($"{tüüp} summa: {isik.ArvutaPalk()} eurot. {((Isik)isik).Nimi}");
                            }
                            break;
                        case "5":
                            Console.WriteLine($"Kõik inimeste arv: {Isik.InimesteKoguarv}");
                            minuKool.KuvaKõik();
                            break;

                        case "6":
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
                            break;

                        case "7":
                            minuKool.SalvestaFaili(path);
                            break;

                        case "8":
                            minuKool.KuvaAinultÕpilased();
                            break;

                        case "9":
                            Console.WriteLine("Kursuse nimi?: ");
                            string kursuseNimi = Console.ReadLine();

                            Console.WriteLine("Vastutava õpetaja nimi?: ");
                            string õpetajaNimi = Console.ReadLine();

                            Õpetaja vastutavÕpetaja = minuKool.inimesed.OfType<Õpetaja>().FirstOrDefault(õ => õ.Nimi.Equals(õpetajaNimi, StringComparison.OrdinalIgnoreCase));

                            if (vastutavÕpetaja != null)
                            {
                                Kursus uusKursus = new Kursus { Nimi = kursuseNimi, VastutavÕpetaja = vastutavÕpetaja };
                                uusKursus.KuvaInfo();
                            }
                            else
                            {
                                Console.WriteLine($"Õpetajat nimega '{õpetajaNimi}' ei leitud süsteemist! Palun lisa õpetaja esmalt.");
                            }
                            break;

                        case "10":

                            Console.WriteLine("Õpetaja nimi:");
                            string õpetajaNimi2 = Console.ReadLine();

                            Õpetaja hindaja = minuKool.inimesed.OfType<Õpetaja>().FirstOrDefault(o => o.Nimi.Equals(õpetajaNimi2,StringComparison.OrdinalIgnoreCase));

                            if (hindaja == null)
                            {
                                Console.WriteLine("Õpetajat ei leitud!");
                                break;
                            }

                            Console.WriteLine("Sisesta hinne:");
                            string hinne = Console.ReadLine();
                            if (int.Parse(hinne) < 0 || int.Parse(hinne) > 5)
                            {
                                Console.WriteLine("Vigane hinne");
                                break;
                            }

                            Console.WriteLine("Sisesta õpilane kellele hinne pani:");
                            string opilane = Console.ReadLine();

                            Õpilane opilanecheck = minuKool.inimesed.OfType<Õpilane>().FirstOrDefault(õ => õ.Nimi.Equals(opilane, StringComparison.OrdinalIgnoreCase));

                            if (opilanecheck != null)
                            {
                                hindaja.Hinda(hinne, opilane);
                            }
                            else
                            {
                                Console.WriteLine($"Õpilane nimega '{opilane}' ei leitud süsteemist! Palun lisa õpetaja esmalt.");
                            }
                            break;

                        case "11":

                            Üliõpilane üliõpilane = new Üliõpilane();

                            Console.WriteLine("Sinu nimi?: ");
                            üliõpilane.Nimi = Console.ReadLine();

                            Console.WriteLine("Sünniaasta?: ");
                            int üliaast = int.Parse(Console.ReadLine());

                            if (üliaast > 1900 && üliaast < 2026)
                            {
                                üliõpilane.Sünniaasta = üliaast;
                            }
                            else
                            {
                                Console.WriteLine("Vigane sünniaasta!");
                                break;
                            }

                            Console.WriteLine("Ülikool?: ");
                            üliõpilane.Kool = Console.ReadLine();

                            Console.WriteLine("Mitmendal kursusel õpid?: ");
                            üliõpilane.Klass = int.Parse(Console.ReadLine());

                            Console.WriteLine("Eriala?: ");
                            üliõpilane.Eriala = Console.ReadLine();

                            Console.WriteLine("Keskmine hinne?: ");
                            üliõpilane.Keskminehinne = double.Parse(Console.ReadLine());

                            Console.WriteLine("Puudumiste arv?: ");
                            üliõpilane.Puudumised = int.Parse(Console.ReadLine());

                            Console.WriteLine("Kas on sotsiaalne tõend? (jah/ei): ");
                            string sots = Console.ReadLine();

                            üliõpilane.KasOnSotsTõend =
                                sots.Equals("jah", StringComparison.OrdinalIgnoreCase);

                            üliõpilane.Staatus =
                                vormid[rnd.Next(vormid.Length)];

                            palgasaajad.Add(üliõpilane);
                            minuKool.LisaInimene(üliõpilane);

                            Console.WriteLine("Üliõpilane lisatud!");
                            break;

                        default:
                            Console.WriteLine("Valik puudub");
                            break;
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
