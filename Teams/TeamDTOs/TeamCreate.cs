namespace API.Teams.TeamDTOs;

public class TeamCreate
{
    public string Name { get; set; }
    
    public string ImageName { get; set; }

    public string Division { get; set; }

    public Guid AssociationID { get; set; }
}