namespace Domain.Core.Domain.Interfaces;

public interface ITrackable
{
    public DateTimeOffset CreationTime { get; set; }
    public string CreatorUserId { get; set; }
}