//.Net Core ile yazılmış Web form uygulaması için Etkinlik kategorilerini görebileceğimiz kod parçası.

using System;
using System.Collections.Generic;

namespace WebFormUygulamasi
{
    // Örnek Etkinlik Kategorisi sınıfı
    public class EventCategory
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public EventCategory(int id, string adi)
        {
            Id = id;
            Adi = adi;
        }
    }

    // Etkinlik Kategori Yönetimi sınıfı
    public class EventCategoryManager
    {
        private List<EventCategory> eventCategories;

        public EventCategoryManager()
        {
            eventCategories = new List<EventCategory>
            {
                new EventCategory(1, "Konferans"),
                new EventCategory(2, "Seminer"),
                new EventCategory(3, "Atolye Çalışması"),
                // Diğer kategorileri ekleyebilirsiniz
            };
        }

        public List<EventCategory> GetEventCategories()
        {
            return eventCategories;
        }
    }

    class Program
    {
        static void Main()
        {
            // Web form uygulamasında kullanılacak olan EventCategoryManager örneği
            EventCategoryManager categoryManager = new EventCategoryManager();

            // Etkinlik kategorilerini al
            List<EventCategory> eventCategories = categoryManager.GetEventCategories();

            // Etkinlik kategorilerini göster
            Console.WriteLine("Etkinlik Kategorileri:");
            foreach (var category in eventCategories)
            {
                Console.WriteLine($"{category.Id}. {category.Adi}");
            }
        }
    }
}
