namespace HesapMakinesi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Giris.IslemGir();
        }
    }

    public enum Islemler
    {
        topla,
        cikar,
        carp,
        bol
    }

    public class Giris
    {
        public static Islemler islem;
        public static void IslemGir()
        {
            bool giris = false;
            while (giris == false)
            {
                try
                {
                    Console.Write("İşlemi giriniz(+,-,*,/): ");
                    string input = Console.ReadLine();

                    islem = input switch
                    {
                        "+" => Islemler.topla,
                        "-" => Islemler.cikar,
                        "*" => Islemler.carp,
                        "/" => Islemler.bol,
                        _ => throw new InvalidOperationException("Geçersiz işlem.")
                    };

                    giris = true;
                }
                catch(Exception e) 
                {
                    Console.WriteLine($"Hata: {e.Message}\n");
                }
                if (giris)
                {
                    SayiGir();
                }
            }
        }

        public static double[] Sayi = new double[2];
        public static void SayiGir()
        {
            for (int i = 0; i < 2; i++)
            {
                bool validNumber = false;
                while (!validNumber)
                {
                    Console.Write(i+1 + ". sayıyı giriniz: ");

                    try
                    {
                        Sayi[i] = Convert.ToInt16(Console.ReadLine());
                        validNumber = true;
                    }
                    catch
                    {
                        Console.WriteLine("Sayı veri türünde değer girilmedi, lütfen tekrar deneyiniz.\n");
                    }
                }
            }

            Islem.Kontrol();
        }

        public class Islem
        {
            public static double sonuc;
            public static void Kontrol()
            {
                double sayi1 = Sayi[0];
                double sayi2 = Sayi[1];

                switch(islem)
                {
                    case Islemler.topla:
                        sonuc = sayi1 + sayi2;
                        break;
                    case Islemler.cikar:
                        sonuc = sayi1 - sayi2;
                        break;
                    case Islemler.carp:
                        sonuc = sayi1 * sayi2;
                        break;
                    case Islemler.bol:
                        if (sayi2 > 0)
                        {
                            sonuc = sayi1 / sayi2;
                        }
                        else
                        {
                            Console.WriteLine("Bölme işleminde 2. sayı 0 olamaz.\n");
                            SayiGir();
                        }
                        break;
                }

                Cıkıs.ConCIkıs();
            }
        }
        
        public class Cıkıs
        {
            public static void ConCIkıs()
            {
                Console.WriteLine($"\nGirilen işlem: {islem}");
                Console.WriteLine ($"Sonucunuz: {Islem.sonuc} ");

                YenidenBasla.YBasla();
            }
        }

        public class YenidenBasla
        {
            public static void YBasla()
            {
                Console.Write("\nYeniden başlamak için 'Enter', Çıkmak için herhangi bir tuşa basınız.");
                if (Console.ReadKey().Key == ConsoleKey.Enter )
                {
                    Console.WriteLine("\n");
                    Program.Main(null);
                }
            }
        }
    }
}