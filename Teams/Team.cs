using System.ComponentModel.DataAnnotations;

public class Team
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public Association? Association { get; set; }

    [MaxLength(5)]
    public required string Split { get; set; }

    public required Division Division { get; set; }
}   