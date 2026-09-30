using API.Players;

public class PlayerAccounts
{
    public Guid Id { get; set; }

    public required Player Player { get; set; }

    public string SummonerName { get; set; } = string.Empty;

    public DateTime OldestDate { get; set; } = DateTime.Now;
}