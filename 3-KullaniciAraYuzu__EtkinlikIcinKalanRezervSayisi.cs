using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Örnek etkinlik oluştur
        Event myEvent = new Event("Konferans", new DateTime(2024, 1, 1), "Ankara", 100);

        // Etkinliğe katılımcı eklemek için
        Participant participant1 = new Participant("Taha", "taha@example.com");
        myEvent.RegisterParticipant(participant1);

        Participant participant2 = new Participant("Ayten", "ayten@example.com");
        myEvent.RegisterParticipant(participant2);

        // Kalan rezerve sayısını göster
        Console.WriteLine($"Kalan Rezerve Sayısı: {myEvent.RemainingCapacity}");
    }
}

public class Event
{
    public string Name { get; }
    public DateTime Date { get; }
    public string Location { get; }
    public int MaxCapacity { get; }
    public List<Participant> Participants { get; }

    public int RemainingCapacity
    {
        get { return MaxCapacity - Participants.Count; }
    }

    public Event(string name, DateTime date, string location, int maxCapacity)
    {
        Name = name;
        Date = date;
        Location = location;
        MaxCapacity = maxCapacity;
        Participants = new List<Participant>();
    }

    public void RegisterParticipant(Participant participant)
    {
        if (RemainingCapacity > 0)
        {
            Participants.Add(participant);
            Console.WriteLine($"{participant.Name} etkinliğe başarıyla kaydedildi. Kalan Rezerve Sayısı: {RemainingCapacity}");
        }
        else
        {
            Console.WriteLine("Etkinlik maksimum kapasiteye ulaştı. Başvuru alınamıyor.");
        }
    }
}

public class Participant
{
    public string Name { get; }
    public string Email { get; }

    public Participant(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
