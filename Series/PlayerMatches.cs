using API.Series.Enumerators;

public class PlayerMatch
{
    public Guid Id { get; set; }

    public required Player Player { get; set; }

    // Can be NULL if lane opponent went AFK
    public Player? Opponent { get; set; }

    public Position Position { get; set; }

    public required Champion Champion { get; set; }

    public required Team Team { get; set; }

    public required Match Match { get; set; }

    public int Kills  { get; set; }

    public int Assists { get; set; }

    public int Deaths { get; set; }

    public int CreepScore { get; set; }

    public int Damage { get; set; }

    public int DamageTaken { get; set; }

    public int Gold { get; set; }

    public int VisionScore { get; set; }

    public int DoubleKills { get; set; }

    public int TripleKills { get; set; }

    public int QuadraKills { get; set; }

    public int PentaKills { get; set; }

    public float KillParticipation { get; set; }

    public float DamagePercentage { get; set; }

    public float GoldPercentage { get; set; }

    public bool FirstBloodAssist { get; set; }

    public bool FirstBloodKill { get; set; }

    public bool Win { get; set; }

}