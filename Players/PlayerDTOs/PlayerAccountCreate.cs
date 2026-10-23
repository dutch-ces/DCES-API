namespace API.Players.PlayerDTOs;

public class PlayerAccountCreate
{
    public string puuid { get; set; }
    
    public bool IsMainAccount { get; set; }

    public string Region { get; set; }

    public string CurrentName { get; set; }
}