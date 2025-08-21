namespace Domain.Entities;
public abstract class BaseEntity
{
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void SetCreated() => CreatedAt = DateTime.UtcNow;
    public void SetUpdated() => UpdatedAt = DateTime.UtcNow;
}
