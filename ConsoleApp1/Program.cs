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
            }
            if (giris)
            {
                SayiGir();
            }
        }
        

        public static int[] Sayi = new int[2];
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
                int sayi1 = Giris.Sayi[0];
                int sayi2 = Giris.Sayi[1];

                Console.WriteLine($"\nGirilen işlem:{islem}");
                
                switch (islem)
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
                        sonuc = sayi1 / sayi2;
                        break;
                }

                Cıkıs.ConCIkıs();
            }
        }
        
        public class Cıkıs
        {
            public static void ConCIkıs()
            {
                Console.WriteLine ("Sonucunuz: " + Islem.sonuc);

                YenidenBasla.YBasla();
            }
        }

        public class YenidenBasla
        {
            public static void YBasla()
            {
                Console.Write("\nTekrar başlamak istiyorsanız 'Enter', Çıkmak için Herhangi bir tuşa basınız: ");

                if (Console.ReadKey().Key == ConsoleKey.Enter )
                {
                    Console.WriteLine("\n");
                    Program.Main(null);
                }
            }
        }
    }
}