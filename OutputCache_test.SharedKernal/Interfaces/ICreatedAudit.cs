namespace OutputCache_test.SharedKernal.Interfaces;

public interface ICreatedAudit
{
    DateTimeOffset CreatedOn { get; set; }

    string? CreatedBy { get; set; }
}
