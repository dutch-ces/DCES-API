namespace API.Players.PlayerDTOs;

public class PlayerTeamCreate
{
    public Guid PlayerID { get; set; }
    
    public Guid TeamID { get; set; }

    public bool IsCaptain { get; set; }

    public bool IsCoach { get; set; }

    public string PlayerType { get; set; } 
}