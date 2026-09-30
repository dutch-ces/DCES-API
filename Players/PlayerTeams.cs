using API.Players.Enumerators;

namespace API.Players
{

    public class PlayerTeams
    {
        public Guid Id { get; set; }

        public required Team Team { get; set; }

        public required Player Player { get; set; }

        public bool IsCaptain { get; set; } = false;

        public bool IsCoach { get; set; } = false;

        public PlayerType Type { get; set; } = PlayerType.NonPlayer;
    }
}
