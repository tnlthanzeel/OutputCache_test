using OutputCache_test.SharedKernal.Interfaces;
using OutputCache_test.SharedKernal.Models;

namespace OutputCache_test.Persistence.AuditSetup;

public sealed class Audit : EntityBase, INoAudit
{
    public string? UserId { get; set; }
    public AuditType AuditType { get; set; }
    public string TableName { get; set; } = null!;
    public DateTimeOffset CreatedOn { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? AffectedColumns { get; set; }
    public string PrimaryKey { get; set; } = null!;
    public Guid BatchId { get; set; }
}
