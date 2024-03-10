namespace Domain.Core.Domain.Interfaces;

public interface IFullAudit : IAudit
{
    public bool? IsDeleted { get; set; }
    public string DeleterUserId { get; set; }
    public DateTimeOffset DeletionTime { get; set; }
}