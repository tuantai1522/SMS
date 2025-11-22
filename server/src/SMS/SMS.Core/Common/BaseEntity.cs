namespace SMS.Core.Common;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}
