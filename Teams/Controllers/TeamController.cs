public class TeamController(TeamService teamService)
{
    public async Task<BaseResult<string>> CreateTeam(TeamCreate teamCreate)
    {
        try
        {
            Team newTeam = await teamService.CreateTeam(teamCreate);
            
            return BaseResult<string>.Ok("Team created:  " + newTeam.Name);
        }
        catch (Exception e) 
        {
            var error = "Creation of Team failed: " + e.Message;
            return BaseResult<string>.Fail(StatusCodes.Status500InternalServerError, "TeamCreationFailed", error);
        }
    }   
}