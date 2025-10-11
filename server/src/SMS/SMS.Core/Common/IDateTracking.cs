namespace SMS.Core.Common;

public interface IDateTracking
{
    public long CreatedAt { get; }
    
    public long? UpdatedAt { get; }
}