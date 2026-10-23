using System.ComponentModel.DataAnnotations;
using API.Players;

public class PlayerAccounts
{
    public Guid Id { get; set; }

    public required Player Player { get; set; }

    [MaxLength(23)]
    public string SummonerName { get; set; } = string.Empty;

    public DateTime OldestDate { get; set; } = DateTime.Now;

    [MaxLength(5)]
    public string Region { get; set; } 
}