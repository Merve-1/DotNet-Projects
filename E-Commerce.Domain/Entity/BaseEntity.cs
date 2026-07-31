namespace E_Commerce.Domain.Entity;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public DateTimeOffset UpdatedAt { get; protected set; }
    
    //ToDo: CreatedById UpdatedById
}