using API.Teams.AssociationDTOs;

namespace API.Teams.Controllers;

public class TeamController(IRepository<Team> teamRepository)
{
    public async Task<string> CreateTeam(TeamCreate teamCreate)
    {
        try
        {
            Team newTeam = new Team
            {
                Name = teamCreate.Name,
                Association = teamCreate.Association,
                Division = teamCreate.division,
                
            };

            await teamRepository.AddAsync(newTeam);
            
            var succes = "Team created:  " + newTeam.Name;
            return succes;
        }
        catch (Exception e) // 100
        {
            var error = "Creation of Team failed: " + e.Message;
            return error;
        }
    }   
}