using System.ComponentModel.DataAnnotations;

public class Association
{
    public Guid Id { get; set; }

    [MaxLength(35)]
    public required string Name { get; set; }
}