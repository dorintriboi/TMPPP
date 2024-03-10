namespace Domain.Core.Domain.Interfaces;

public interface IAudit : ITrackable
{
    public string LastModifierUserId { get; set; }
    public DateTimeOffset LastModificationTime { get; set; }
}