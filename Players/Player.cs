using System.ComponentModel.DataAnnotations;

namespace API.Players
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        public required string DiscordName { get; set; }

        public required string DiscordUserName { get; set; }

        [MaxLength(2)]
        public required string Nationality { get; set; }

        // Association ID
    }
}
