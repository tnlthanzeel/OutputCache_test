namespace OutputCache_test.SharedKernal.Interfaces;

public interface IUpdatedAudit
{
    DateTimeOffset? UpdatedOn { get; set; }

    string? UpdatedBy { get; set; }
}
