using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Örnek etkinlik oluştur
        Conference myConference = new Conference("Teknoloji Konferansı", "Congresium Kongre Merkezi", new DateTime(2024, 2, 1), 5, 10);

        // Etkinliğe katılımcı eklemek için
        Participant participant1 = new Participant("Taha", "taha@example.com");
        myConference.RegisterParticipant(participant1, 2, 3); // 2. sıradaki 3. koltuğa otur

        // Bilet satışı yapmak için
        Ticket ticket1 = myConference.SellTicket(participant1, 2, 3);

        // Bilet geçmişini göster
        Console.WriteLine("Bilet Geçmişi:");
        foreach (var ticket in myConference.TicketHistory)
        {
            Console.WriteLine($"{ticket.Participant.Name} - {ticket.Seat.Row}. sıra {ticket.Seat.Number}. koltuk - {ticket.SaleDate}");
        }
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
    public List<Ticket> TicketHistory { get; }

    public Conference(string name, string venue, DateTime date, int totalRows, int seatsPerRow)
    {
        Name = name;
        Venue = venue;
        Date = date;
        TotalRows = totalRows;
        SeatsPerRow = seatsPerRow;
        SeatMatrix = new bool[totalRows, seatsPerRow];
        TicketHistory = new List<Ticket>();
    }

    public void RegisterParticipant(Participant participant, int row, int seat)
    {
        // Aynı katılımcının aynı koltuğa tekrar kaydını önlemek için kontrol ekleyebilirsiniz
        if (IsValidSeat(row, seat) && !SeatMatrix[row - 1, seat - 1])
        {
            SeatMatrix[row - 1, seat - 1] = true;
            Console.WriteLine($"{participant.Name} etkinliğe başarıyla kaydedildi. {row}. sıradaki {seat}. koltukta oturacak.");
        }
        else
        {
            Console.WriteLine("Geçersiz koltuk seçimi. Lütfen başka bir koltuk seçin.");
        }
    }

    public Ticket SellTicket(Participant participant, int row, int seat)
    {
        if (IsValidSeat(row, seat) && SeatMatrix[row - 1, seat - 1])
        {
            SeatMatrix[row - 1, seat - 1] = false;
            Ticket ticket = new Ticket(participant, new Seat(row, seat), DateTime.Now);
            TicketHistory.Add(ticket);
            Console.WriteLine($"{participant.Name} için bilet satıldı. {row}. sıra {seat}. koltuk - {ticket.SaleDate}");
            return ticket;
        }
        else
        {
            Console.WriteLine("Geçersiz koltuk seçimi. Satış yapılamıyor.");
            return null;
        }
    }

    private bool IsValidSeat(int row, int seat)
    {
        return row > 0 && row <= TotalRows && seat > 0 && seat <= SeatsPerRow;
    }
}

public class Ticket
{
    public Participant Participant { get; }
    public Seat Seat { get; }
    public DateTime SaleDate { get; }

    public Ticket(Participant participant, Seat seat, DateTime saleDate)
    {
        Participant = participant;
        Seat = seat;
        SaleDate = saleDate;
    }
}

public class Seat
{
    public int Row { get; }
    public int Number { get; }

    public Seat(int row, int number)
    {
        Row = row;
        Number = number;
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
