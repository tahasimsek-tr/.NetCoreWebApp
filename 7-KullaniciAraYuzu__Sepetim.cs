//Bilet satın almak istediğinde ödeme işlemi öncesi ‘Sepetim’ klasörüne düşürecek
using System;
using System.Collections.Generic;

namespace WebFormUygulamasi
{
    // Örnek Bilet sınıfı
    public class Bilet
    {
        public string BiletAdi { get; set; }
        public decimal Fiyat { get; set; }
        // Diğer bilgileri ekleyebilirsiniz

        public Bilet(string biletAdi, decimal fiyat)
        {
            BiletAdi = biletAdi;
            Fiyat = fiyat;
        }
    }

    // Alışveriş Sepeti sınıfı
    public class ShoppingCart
    {
        private List<Bilet> sepetItems;

        public ShoppingCart()
        {
            sepetItems = new List<Bilet>();
        }

        public void BiletEkle(Bilet bilet)
        {
            sepetItems.Add(bilet);
            Console.WriteLine($"{bilet.BiletAdi} sepete eklendi. Toplam: {ToplamFiyat()} TL");
        }

        public void SepetiGoster()
        {
            Console.WriteLine("Sepetinizdeki Biletler:");
            foreach (var bilet in sepetItems)
            {
                Console.WriteLine($"{bilet.BiletAdi} - {bilet.Fiyat} TL");
            }
            Console.WriteLine($"Toplam Fiyat: {ToplamFiyat()} TL");
        }

        public decimal ToplamFiyat()
        {
            decimal toplamFiyat = 0;
            foreach (var bilet in sepetItems)
            {
                toplamFiyat += bilet.Fiyat;
            }
            return toplamFiyat;
        }
    }

    class Program
    {
        static void Main()
        {
            // Web form uygulamasında kullanılacak olan ShoppingCart örneği
            ShoppingCart sepet = new ShoppingCart();

            // Biletler oluşturulur
            Bilet bilet1 = new Bilet("Konferans Bileti", 100);
            Bilet bilet2 = new Bilet("Workshop Bileti", 50);

            // Biletler sepete eklenir
            sepet.BiletEkle(bilet1);
            sepet.BiletEkle(bilet2);

            // Sepeti göster
            sepet.SepetiGoster();
        }
    }
}
