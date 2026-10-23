public class TeamCreate
{
    public string Name { get; set; }
    
    public string ImageName { get; set; }

    public Guid DivisionId { get; set; }

    public Guid? AssociationId { get; set; }
    
    public string Split { get; set; }
}