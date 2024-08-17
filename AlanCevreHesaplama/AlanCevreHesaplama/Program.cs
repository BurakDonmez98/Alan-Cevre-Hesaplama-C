using System;

class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {

            Console.WriteLine("İşlem seçiniz:");
            Console.WriteLine("Hesaplama için '1 ardından Enter tuşuna basınız.'");
            Console.WriteLine("Çıkış için '0 ardından Enter tuşuna basınız.'");

            int anaSecim = GecerliGirdiAl(0, 1);

            if (anaSecim == 0)//Hesaplama yada çıkış yapılacak alan
            {
                Console.WriteLine("Programdan çıkılıyor...");
                break;
            }

            Console.WriteLine("İşlem türünü seçiniz:");
            Console.WriteLine("Alan için '1 ardından Enter tuşuna basınız.'");
            Console.WriteLine("Çevre için '2 ardından Enter tuşuna basınız.'");

            int islemTuru = GecerliGirdiAl(1, 2);

            Console.WriteLine("Şekil seçiniz:");
            Console.WriteLine("Üçgen için '1 ardından Enter tuşuna basınız.'");
            Console.WriteLine("Kare için '2 ardından Enter tuşuna basınız.'");
            Console.WriteLine("Dikdörtgen için '3 ardından Enter tuşuna basınız.'");
            Console.WriteLine("Daire için '4 ardından Enter tuşuna basınız.'");

            int sekilSecim = GecerliGirdiAl(1, 4);

            double sonuc = 0;

            switch (sekilSecim)// Hesaplama seçiminden sonra hangi şekil ile işlem yapılacağının seçim menüsü.
            {
                case 1:// Seçim eğer üçgen ise üçgen hesaplama metodunu çağırır. Değil ise devam eder.
                    Console.WriteLine("Üçgen türünü seçiniz:");
                    Console.WriteLine("Eşkenar üçgen için '1 ardından Enter tuşuna basınız.'");
                    Console.WriteLine("İkizkenar üçgen için '2 ardından Enter tuşuna basınız.'");
                    Console.WriteLine("Çeşitkenar üçgen için '3 ardından Enter tuşuna basınız.'");

                    int ucgenTuru = GecerliGirdiAl(1, 3);
                    sonuc = UcgenHesapla(islemTuru, ucgenTuru);
                    break;

                case 2:// Seçim eğer kare ise kare hesaplama metodunu çağırır.Değil ise devam eder.
                    sonuc = KareHesapla(islemTuru);
                    break;

                case 3:// Seçim eğer dikdörtgen ise dikdörtgen hesaplama metodunu çağırır.Değil ise devam eder.
                    sonuc = DikdortgenHesapla(islemTuru);
                    break;

                case 4: // Seçim eğer daire ise daire hesaplama metodunu çağırır.
                    sonuc = DaireHesapla(islemTuru);
                    break;
            }

            Console.WriteLine("Sonuç: " + sonuc);
        }

        int GecerliGirdiAl(int min, int max) // Alınacak değer int ise bu metod kullanılır. İstenilen aralığı metodu çağırırken belirtebiliriz aksi taktirde hata mesajı döner 
        {
            int secim;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out secim) && secim >= min && secim <= max)
                {
                    return secim;
                }
                Console.WriteLine($"Lütfen {min} ile {max} arasında geçerli bir değer giriniz:");
            }
        }

        double GecerliDoubleGirdiAl() // Alınacak değerin double veri tipinde olması gerekiyorsa bu metod kullanılır
        {
            double input;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                Console.WriteLine("Lütfen geçerli bir sayı giriniz:");
            }
        }

        double UcgenHesapla(int islemTuru, int ucgenTuru) // Seçim eğer üçgen ise hesaplamanın yapılacağı metod
        {
            switch (ucgenTuru)
            {
                case 1: // Eşkenar Üçgen hesaplama işlemleri yapıldığı alan
                    Console.WriteLine("Bir kenar uzunluğunu giriniz:");
                    double kenar = GecerliDoubleGirdiAl();
                    if (islemTuru == 1)
                        return Math.Sqrt(3) / 4 * Math.Pow(kenar, 2); // Eşkenar Üçgen Alanın hesaplanıp consola yazdırıldığı yer.
                    else
                        return 3 * kenar; // Eşkenar Üçgen Çevrenin hesaplanıp consola yazdırıldığı yer.

                case 2: // İkizkenar Üçgen Hesaplama işlemleri 
                    Console.WriteLine("Eşit iki kenar uzunluğunu giriniz:");
                    double esitKenar = GecerliDoubleGirdiAl();
                    Console.WriteLine("Taban uzunluğunu giriniz:");
                    double taban = GecerliDoubleGirdiAl();
                    if (islemTuru == 1)
                    {
                        double yukseklik = Math.Sqrt(Math.Pow(esitKenar, 2) - Math.Pow(taban / 2, 2));
                        return taban * yukseklik / 2; // İkizkenar Üçgen Alanın hesaplanıp consola yazdırıldığı yer
                    }
                    else
                        return 2 * esitKenar + taban; // İkizkenar Üçgen Çevresinin hesaplanıp consola yazdırıldığı yer

                case 3: // Çeşitkenar Üçgen Hesaplama işlemleri
                    Console.WriteLine("Birinci kenar uzunluğunu giriniz:");
                    double kenar1 = GecerliDoubleGirdiAl();
                    Console.WriteLine("İkinci kenar uzunluğunu giriniz:");
                    double kenar2 = GecerliDoubleGirdiAl();
                    Console.WriteLine("Üçüncü kenar uzunluğunu giriniz:");
                    double kenar3 = GecerliDoubleGirdiAl();
                    if (islemTuru == 1)
                    {
                        double s = (kenar1 + kenar2 + kenar3) / 2;
                        return Math.Sqrt(s * (s - kenar1) * (s - kenar2) * (s - kenar3)); // Çeşitkenar Üçgen Alanının hesaplanıp consola yazdırıldığı yer 
                    }
                    else
                        return kenar1 + kenar2 + kenar3; // Çeşitkenar Üçgenin Çevresinin hesaplanıp consola yazdırıldığı yer
            }
            return 0;
        }

        double KareHesapla(int islemTuru)// Seçim eğer kare ise hesaplamanın yapılacağı metod
        {
            Console.WriteLine("Bir kenar uzunluğunu giriniz:");
            double kenar = GecerliDoubleGirdiAl();
            if (islemTuru == 1)
                return Math.Pow(kenar, 2); // Kare için Alanın hesaplanıp consola yazdırıldığı yer
            else
                return 4 * kenar; // Kare için Çevresinin hesaplanıp yazdırıldığı yer
        }

        double DikdortgenHesapla(int islemTuru)// Seçim eğer dikdörtgen ise hesaplamanın yapılacağı metod
        {
            Console.WriteLine("Birinci kenar uzunluğunu giriniz:");
            double kenar1 = GecerliDoubleGirdiAl();
            Console.WriteLine("İkinci kenar uzunluğunu giriniz:");
            double kenar2 = GecerliDoubleGirdiAl();
            if (islemTuru == 1)
                return kenar1 * kenar2; // Dikdortgen için Alan hesaplamasının yapılıp consola yazdırıldığı alan
            else
                return 2 * (kenar1 + kenar2); // Dikdortgen için Çevre hesaplamasının yapılıp consola yazdırıldığı alan
        }

        double DaireHesapla(int islemTuru)// Seçim eğer daire ise hesaplamanın yapılacağı metod
        {
            Console.WriteLine("Yarıçapı giriniz:");
            double yaricap = GecerliDoubleGirdiAl();
            if (islemTuru == 1)
                return Math.PI * Math.Pow(yaricap, 2); // Daire için Alan hesaplamasının yapılıp consola yazdırıldığı alan
            else
                return 2 * Math.PI * yaricap; // Daire için Çevre hesaplamasının yapılıp consola yazdırıldığı alan
        }
    }
}