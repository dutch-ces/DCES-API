using System.ComponentModel.DataAnnotations;

public class Player
{
    [Key]
    public Guid Id { get; set; }

    public required string DiscordName { get; set; }

    public required string DiscordUserName { get; set; }

    [MaxLength(2)]
    public required string Nationality { get; set; }

    public Association? Association { get; set; }
}