using System.ComponentModel.DataAnnotations;
using API.Base;

public class Association : IDeletable
{
    public Guid Id { get; set; }

    [MaxLength(35)]
    public required string Name { get; set; }
    
    public string Logo { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
    
    public DateTime? DeletedAt { get; set; }
}