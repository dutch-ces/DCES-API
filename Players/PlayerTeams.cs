using API.Players.Enumerators;

namespace API.Players
{

    public class PlayerTeams
    {
        public Guid Id { get; set; }

        // Team

        public required Player Player { get; set; }

        public Boolean IsCaptain { get; set; } = false;

        public Boolean IsCoach { get; set; } = false;

        public PlayerType Type { get; set; } = PlayerType.NonPlayer;
    }
}
