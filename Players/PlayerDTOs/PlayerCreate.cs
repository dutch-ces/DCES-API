namespace API.Players.PlayerDTOs;

public class PlayerCreate
{
    public string DisplayName { get; set; }
    
    public string DiscordUsername { get; set; }

    public string? Nationality1 { get; set; }

    public string? Nationality2 { get; set; }

    public Guid Association_id { get; set; }
}

public class PlayerSubstituteCreate
{
    public string DisplayName { get; set; }
}