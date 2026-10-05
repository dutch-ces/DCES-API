public class Match
{
    public Guid Id { get; set; }

    public required Team BlueTeam { get; set; } = null!;

    public required Team RedTeam { get; set; } = null!;

    public required Team Winner { get; set; } = null!;

    public required Series Series { get; set; } = null!;

    public string GameId { get; set; } = string.Empty;

    public Team? FirstDragon { get; set; }

    public Team? FirstBaron { get; set; }

    public Team? FirstTower { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public bool Forfeit { get; set; } = false;
}