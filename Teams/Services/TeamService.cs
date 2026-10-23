public class TeamService(
    IRepository<Team> teamRepository, 
    IRepository<Association>  associationRepository,
    IRepository<Division> divisionRepository)
{
    public async Task<Team> CreateTeam(TeamCreate teamCreate)
    {
        Association? association = null;
        if (teamCreate.AssociationId != null)
        {
            association = await associationRepository.GetByIdAsync(teamCreate.AssociationId);

            if (association == null)
            {
                throw new Exception($"Association with ID {teamCreate.AssociationId} not found");
            }
        }

        Division? division = await divisionRepository.GetByIdAsync(teamCreate.DivisionId);
        
        if (division == null)  throw new Exception("Division not found with id: " + teamCreate.DivisionId);  
        
        Team newTeam = new Team
        {
            Name = teamCreate.Name,
            Association = association,
            Division = division,
            Split = teamCreate.Split,
        };

        await teamRepository.AddAsync(newTeam);
        await teamRepository.SaveChangesAsync();
        return newTeam;
    }
}