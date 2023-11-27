namespace OutputCache_test.SharedKernal.Interfaces;

public interface IDeletedAudit
{
    DateTimeOffset? DeletedOn { get; set; }

    string? DeletedBy { get; set; }
    public bool IsDeleted { get; }
}
