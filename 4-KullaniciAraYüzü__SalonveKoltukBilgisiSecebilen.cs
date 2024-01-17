using System;

class Program
{
    static void Main()
    {
        // Örnek konferans oluştur
        Conference myConference = new Conference("Teknoloji Konferansı", "Congresium Kongre Merkezi", 5, 10);

        // Katılımcıları kaydet
        Participant participant1 = new Participant("Taha", "taha@example.com");
        myConference.RegisterParticipant(participant1, 2, 3); // 2. sıradaki 3. koltuğa otur

        Participant participant2 = new Participant("Ayten", "ayten@example.com");
        myConference.RegisterParticipant(participant2, 1, 5); // 1. sıradaki 5. koltuğa otur

        // Koltuk durumunu göster
        myConference.DisplaySeatStatus();
    }
}

public class Conference
{
    public string Name { get; }
    public string Venue { get; }
    public int TotalRows { get; }
    public int SeatsPerRow { get; }
    public bool[,] SeatMatrix { get; }

    public Conference(string name, string venue, int totalRows, int seatsPerRow)
    {
        Name = name;
        Venue = venue;
        TotalRows = totalRows;
        SeatsPerRow = seatsPerRow;
        SeatMatrix = new bool[totalRows, seatsPerRow];
    }

    public void RegisterParticipant(Participant participant, int row, int seat)
    {
        if (IsValidSeat(row, seat) && !SeatMatrix[row - 1, seat - 1])
        {
            SeatMatrix[row - 1, seat - 1] = true;
            Console.WriteLine($"{participant.Name} konferansa başarıyla kaydedildi. {row}. sıradaki {seat}. koltukta oturacak.");
        }
        else
        {
            Console.WriteLine("Geçersiz koltuk seçimi. Lütfen başka bir koltuk seçin.");
        }
    }

    public void DisplaySeatStatus()
    {
        Console.WriteLine("Koltuk Durumu:");
        for (int i = 0; i < TotalRows; i++)
        {
            for (int j = 0; j < SeatsPerRow; j++)
            {
                Console.Write(SeatMatrix[i, j] ? "X " : "O ");
            }
            Console.WriteLine();
        }
    }

    private bool IsValidSeat(int row, int seat)
    {
        return row > 0 && row <= TotalRows && seat > 0 && seat <= SeatsPerRow;
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
