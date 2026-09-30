using API.Division;
public class Series
{
    public Guid Id { get; set; }

    public required Division Division { get; set; }

    public int Stage { get; set; }

    public int Round { get; set; }

    public bool IsUpper { get; set; }

    public required Team Team1 { get; set; }

    public required Team Team2 { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public Team? Winner { get; set; }

    public bool Tie { get; set; } = false;

    public DateTime ScheduledDate { get; set; }

    public bool Played { get; set; } = false;

    public bool Forfeit { get; set; } = false;
}

