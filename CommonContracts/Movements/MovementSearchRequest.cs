namespace CommonContracts.Movements
{
    public sealed record MovementSearchRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 25;
        public string[]? MovementNumbers { get; init; }
        public long? JobID { get; init; }
        public long[]? StatusIDs { get; init; }
        public DateTimeOffset? FromDate { get; init; }
        public DateTimeOffset? ToDate { get; init; }
    }
}
