namespace CommonContracts.Movements
{
    public sealed record MovementJobSummary
    {
        public required string JobNumber { get; init; }
        public required string BranchName { get; init; }
        public required string AccountName { get; init; }
        public string? OrderNumber { get; init; }
        public string? InvoiceNumber { get; init; }
    }
}
