using System.ComponentModel.DataAnnotations;

public class Player
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public required string DiscordName { get; set; }

    [MaxLength(100)]
    public required string DiscordUserName { get; set; }

    [MaxLength(2)]
    public required string Nationality { get; set; }

    public Association? Association { get; set; }
}