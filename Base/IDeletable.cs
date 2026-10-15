namespace API.Base;

public interface IDeletable
{
    public  bool IsDeleted { get; set; }
    
    public DateTime? DeletedAt { get; set; }
}