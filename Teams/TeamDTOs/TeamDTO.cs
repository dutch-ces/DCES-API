public class TeamDTO
{   
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string ImageUrl { get; set; }

    public Guid? AssociationId { get; set; }

    public string Split { get; set; }
   
    public Guid DivisionId { get; set; }
}