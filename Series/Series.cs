using System.ComponentModel.DataAnnotations;

public class Series
{
    public Guid Id { get; set; }

    public required Division Division { get; set; }

    public required int Stage { get; set; }

    [Range(1, 7, ErrorMessage = "Round must be between 1 and 7.")]
    public required int Round { get; set; }

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
