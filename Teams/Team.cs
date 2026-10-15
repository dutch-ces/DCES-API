using System.ComponentModel.DataAnnotations;
using API.Base;

public class Team : IDeletable
{
    public Guid Id { get; set; }

    [MaxLength(35)]
    public required string Name { get; set; }

    public Association? Association { get; set; }

    [MaxLength(5)]
    public required string Split { get; set; }

    public required Division Division { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}   