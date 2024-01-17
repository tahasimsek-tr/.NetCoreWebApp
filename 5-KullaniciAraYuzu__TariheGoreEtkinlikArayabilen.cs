using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Örnek etkinlikler oluştur
        Conference conference1 = new Conference("Teknoloji Konferansı", "Congresium Kongre Merkezi", new DateTime(2024, 2, 1), 5, 10);
        Conference conference2 = new Conference("İş Geliştirme Konferansı", "Ankara Fuar Merkezi", new DateTime(2024, 3, 15), 6, 8);

        // Etkinlikleri bir listeye ekle
        List<Conference> conferences = new List<Conference> { conference1, conference2 };

        // Belirli bir tarihe göre etkinlikleri ara
        DateTime searchDate = new DateTime(2024, 3, 1);
        List<Conference> foundConferences = SearchConferencesByDate(conferences, searchDate);

        // Bulunan etkinlikleri liste
        Console.WriteLine($" {searchDate} tarihindeki Etkinlikler:");
        foreach (var foundConference in foundConferences)
        {
            Console.WriteLine($"- {foundConference.Name} ({foundConference.Date.ToShortDateString()}) - {foundConference.Venue}");
        }
    }

    static List<Conference> SearchConferencesByDate(List<Conference> conferences, DateTime searchDate)
    {
        return conferences.Where(conference => conference.Date.Date == searchDate.Date).ToList();
    }
}

public class Conference
{
    public string Name { get; }
    public string Venue { get; }
    public DateTime Date { get; }
    public int TotalRows { get; }
    public int SeatsPerRow { get; }
    public bool[,] SeatMatrix { get; }

    public Conference(string name, string venue, DateTime date, int totalRows, int seatsPerRow)
    {
        Name = name;
        Venue = venue;
        Date = date;
        TotalRows = totalRows;
        SeatsPerRow = seatsPerRow;
        SeatMatrix = new bool[totalRows, seatsPerRow];
    }
}
