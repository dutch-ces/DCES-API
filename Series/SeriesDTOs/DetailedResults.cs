using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class LolDetailedMatchPlayerDTO
{
    public PlayerDTO Player { get; set; }

    public int Kills { get; set; }

    public int Deaths { get; set; }

    public int Assists { get; set; }

    public double KillParticipation { get; set; }

    public int CreepScore { get; set; }

    public LolChampionDTO Champion { get; set; } = null!;

    public int Level { get; set; }

    public int Damage { get; set; }

    public int DamageTaken { get; set; }

    public int Summoner1Id { get; set; }

    public int Summoner2Id { get; set; }

    public int Rune1Id { get; set; }

    public int Rune2Id { get; set; }

    public int VisionScore { get; set; }

    [MaxLength(7)]
    public List<LolItemDTO> Items { get; set; } = new();

    public LolItemDTO Trinket { get; set; } = null!;

    public int Position { get; set; }

    public double? DmgPercent { get; set; }
}

public class LolDetailedMatchTeamDTO
{
    [MinLength(5)]
    [MaxLength(5)]
    public List<LolDetailedMatchPlayerDTO> Players { get; set; } = new();

    public int Barons { get; set; }

    public int Dragons { get; set; }

    public int Towers { get; set; }

    public int VoidGrubs { get; set; }

    public int Inhibitors { get; set; }

    public int Heralds { get; set; }
}

public class LolDetailedMatchResultDTO
{
    public TeamDTO? BlueTeam { get; set; }

    public TeamDTO? RedTeam { get; set; }

    public LolDetailedMatchTeamDTO? BlueTeamStats { get; set; }

    public LolDetailedMatchTeamDTO? RedTeamStats { get; set; }

    [MaxLength(5)]
    public List<LolChampionDTO>? BlueTeamBans { get; set; }

    [MaxLength(5)]
    public List<LolChampionDTO>? RedTeamBans { get; set; }

    public bool Forfeit { get; set; }

    public int Duration { get; set; }
}

public class LolDetailedSeriesResultDTO
{
    public TeamDTO Team1 { get; set; } = null!;

    public TeamDTO Team2 { get; set; } = null!;

    public int BestOf { get; set; }

    public DateTime Time { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public bool Forfeit { get; set; }

    public Stage Stage { get; set; }

    public int Round { get; set; }

    public List<LolDetailedMatchResultDTO> Matches { get; set; } = new();
}