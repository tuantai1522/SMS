namespace SMS.Core.Common;

public interface ISoftDelete
{
    public long? DeletedAt { get; }

    public void Delete();
}