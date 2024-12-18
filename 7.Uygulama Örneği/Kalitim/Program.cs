using System;

namespace HepsiBirArada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistem seçiniz:\n1. Çalışan Yönetim Sistemi\n2. Hayvanat Bahçesi Yönetim Sistemi\n3. Banka Yönetim Sistemi");
            int sistemSecimi = int.Parse(Console.ReadLine());

            switch (sistemSecimi)
            {
                case 1:
                    CalisanYonetimSistemi();
                    break;
                case 2:
                    HayvanatBahcesiYonetim();
                    break;
                case 3:
                    BankaYonetimSistemi();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                    break;
            }
        }

        static void CalisanYonetimSistemi()
        {
            Console.WriteLine("Çalışan türünü seçiniz (1: Yazılımcı, 2: Muhasebeci):");
            int secim = int.Parse(Console.ReadLine());
            Calisan calisan;

            if (secim == 1)
            {
                calisan = new Yazilimci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());
                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }
            else if (secim == 2)
            {
                calisan = new Muhasebeci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());
                Console.Write("Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                return;
            }

            Console.WriteLine("\nÇalışan Bilgileri:");
            calisan.BilgiYazdir();
        }

        static void HayvanatBahcesiYonetim()
        {
            Console.WriteLine("Hayvan türünü seçiniz (1: Memeli, 2: Kuş):");
            int secim = int.Parse(Console.ReadLine());
            Hayvan hayvan;

            if (secim == 1)
            {
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else if (secim == 2)
            {
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği (cm): ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                return;
            }

            Console.WriteLine("\nHayvan Bilgileri:");
            Console.WriteLine($"Ad: {hayvan.Ad}, Tür: {hayvan.Tur}, Yaş: {hayvan.Yas}");
            hayvan.SesCikar();
        }

        static void BankaYonetimSistemi()
        {
            Console.WriteLine("Hesap türünü seçiniz (1: Vadesiz Hesap, 2: Vadeli Hesap):");
            int secim = int.Parse(Console.ReadLine());
            Hesap hesap;

            if (secim == 1)
            {
                hesap = new VadesizHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = double.Parse(Console.ReadLine());
            }
            else if (secim == 2)
            {
                hesap = new VadeliHesap();
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı (%): ");
                ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                return;
            }

            Console.WriteLine("\nHesap Bilgileri:");
            hesap.BilgiYazdir();
        }
    }

    // Çalışan sınıfı ve türevleri
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double Maas { get; set; }
        public virtual void BilgiYazdir() => Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}");
    }

    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }
        public override void BilgiYazdir() => Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Yazılım Dili: {YazilimDili}");
    }

    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }
        public override void BilgiYazdir() => Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Muhasebe Yazılımı: {MuhasebeYazilimi}");
    }

    // Hayvan sınıfı ve türevleri
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }
        public virtual void SesCikar() => Console.WriteLine("Bu hayvan bir ses çıkarıyor.");
    }

    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }
        public override void SesCikar() => Console.WriteLine("Memeli: Mrrr!");
    }

    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }
        public override void SesCikar() => Console.WriteLine("Kuş: Cik cik!");
    }

    // Hesap sınıfı ve türevleri
    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public double Bakiye { get; set; }
        public string HesapSahibi { get; set; }
        public virtual void BilgiYazdir() => Console.WriteLine($"Hesap No: {HesapNumarasi}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}");
    }

    class VadesizHesap : Hesap
    {
        public double EkHesapLimiti { get; set; }
        public override void BilgiYazdir() => Console.WriteLine($"Hesap No: {HesapNumarasi}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}, Ek Hesap Limiti: {EkHesapLimiti}");
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }
        public override void BilgiYazdir() => Console.WriteLine($"Hesap No: {HesapNumarasi}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}, Vade Süresi: {VadeSuresi} gün, Faiz Oranı: %{FaizOrani}");
    }
}
