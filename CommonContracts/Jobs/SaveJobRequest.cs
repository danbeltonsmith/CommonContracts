namespace CommonContracts.Jobs
{
    public sealed record SaveJobRequest
    {
        public required string JobNumber { get; init; }
        public required DateTimeOffset Date { get; init; }
        public required long BranchID { get; init; }
        public required long AccountID { get; init; }
        public required long OriginLocationID { get; init; }
        public required long DestinationLocationID { get; init; }
        public string? QuoteNumber { get; init; }
        public string? Description { get; init; }
        public required long StatusID { get; init; }
        public string? OrderNumber { get; init; }
        public string? InvoiceNumber { get; init; }
        public DateTimeOffset? InvoiceDate { get; init; }
        public List<CostAccrualRequest> CostAccruals { get; init; } = [];
        public List<NewJobMovementRequest> NewMovements { get; init; } = [];
        public List<ExistingJobMovementRequest> ExistingMovements { get; init; } = [];
    }
}
