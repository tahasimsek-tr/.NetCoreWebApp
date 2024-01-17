using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Örnek etkinlik oluştur
        Event myEvent = new Event("Konferans", new DateTime(2024, 1, 1), "İstanbul");

        // Etkinliğe katılımcı eklemek için
        Participant participant1 = new Participant("Taha", "taha@example.com");
        myEvent.RegisterParticipant(participant1);

        Participant participant2 = new Participant("Ayten", "ayten@example.com");
        myEvent.RegisterParticipant(participant2);

        // Katılımcıları listele
        Console.WriteLine("Katılımcılar:");
        foreach (var participant in myEvent.Participants)
        {
            Console.WriteLine(participant.ToString());
        }
    }
}

public class Event
{
    public string Name { get; }
    public DateTime Date { get; }
    public string Location { get; }
    public List<Participant> Participants { get; }

    public Event(string name, DateTime date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
        Participants = new List<Participant>();
    }

    public void RegisterParticipant(Participant participant)
    {
        Participants.Add(participant);
        Console.WriteLine($"{participant.Name} etkinliğe başarıyla kaydedildi.");
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

    public override string ToString()
    {
        return $"{Name} ({Email})";
    }
}
