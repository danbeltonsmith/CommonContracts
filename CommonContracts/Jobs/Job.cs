using CommonContracts.Movements;
using CommonContracts.Shared;

namespace CommonContracts.Jobs
{
    public sealed record Job
    {
        public required long ID { get; init; }
        public required string JobNumber { get; init; }
        public required DateTimeOffset Date { get; init; }
        public required BranchReference Branch { get; init; }
        public required AccountReference Account { get; init; }
        public required LocationReference Origin { get; init; }
        public required LocationReference Destination { get; init; }
        public string? QuoteNumber { get; init; }
        public string? Description { get; init; }
        public required LookupValue Status { get; init; }
        public string? OrderNumber { get; init; }
        public string? InvoiceNumber { get; init; }
        public DateTimeOffset? InvoiceDate { get; init; }
        public decimal? ChargeAmount { get; init; }
        public List<CostAccrual> CostAccruals { get; init; } = [];
        public List<JobDocument> Documents { get; init; } = [];
        public List<Movement> Movements { get; init; } = [];
        public required bool Active { get; init; }
        public required AuditUser CreatedBy { get; init; }
        public required DateTimeOffset CreatedDate { get; init; }
        public AuditUser? ModifiedBy { get; init; }
        public DateTimeOffset? ModifiedDate { get; init; }
    }
}
