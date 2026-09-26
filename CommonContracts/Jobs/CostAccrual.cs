using CommonContracts.Shared;

namespace CommonContracts.Jobs
{
    public sealed record CostAccrual
    {
        public required long ID { get; init; }
        public required LookupValue AccrualType { get; init; }
        public required decimal Amount { get; init; }
        public required bool Active { get; init; }
        public required AuditUser CreatedBy { get; init; }
        public required DateTimeOffset CreatedDate { get; init; }
        public AuditUser? ModifiedBy { get; init; }
        public DateTimeOffset? ModifiedDate { get; init; }
    }
}
