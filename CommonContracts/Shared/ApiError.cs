namespace CommonContracts.Shared
{
    public sealed record ApiError
    {
        public required string Message { get; init; }
        public required string ErrorCode { get; init; }
        public object? Details { get; init; }
        public required int Status { get; init; }
        public required DateTime Timestamp { get; init; }
    }
}
