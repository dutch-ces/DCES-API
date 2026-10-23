using System;
using System.Collections.Generic;

public class SeriesResultDTO
{
    public TeamDTO Team1 { get; set; }
    public TeamDTO Team2 { get; set; }
    public DateTime Time { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public bool Forfeit { get; set; }
    public Stage Stage { get; set; }
    public int Round { get; set; }
    public int BestOf { get; set; }
}

public class LolSeriesMatchResultDTO
{
    public TeamDTO? BlueTeam { get; set; }
    public TeamDTO? RedTeam { get; set; }
    public List<LolChampionDTO>? BlueTeamChamps { get; set; }
    public List<LolChampionDTO>? RedTeamChamps { get; set; }
    public bool Forfeit { get; set; }
}

public class LolSeriesResultDTO : SeriesResultDTO
{
    public List<LolSeriesMatchResultDTO> Matches { get; set; } = new();
}

public class CsSeriesMatchResultDTO
{
    public TeamDTO? Team1 { get; set; }
    public TeamDTO? Team2 { get; set; }
    public int? Team1Score { get; set; }
    public int? Team2Score { get; set; }
    public GameMapDTO? Map { get; set; }
    public bool Forfeit { get; set; }
}

public class CsSeriesResultDTO : SeriesResultDTO
{
    public List<CsSeriesMatchResultDTO> Matches { get; set; } = new();
}

public class ValoSeriesMatchResultDTO
{
    public TeamDTO? Team1 { get; set; }
    public TeamDTO? Team2 { get; set; }
    public List<ValoAgentDTO>? Team1Agents { get; set; }
    public List<ValoAgentDTO>? Team2Agents { get; set; }
    public int? Team1Score { get; set; }
    public int? Team2Score { get; set; }
    public bool Forfeit { get; set; }
    public GameMapDTO? Map { get; set; }
}

public class ValoSeriesResultDTO : SeriesResultDTO
{
    public List<ValoSeriesMatchResultDTO> Matches { get; set; } = new();
}