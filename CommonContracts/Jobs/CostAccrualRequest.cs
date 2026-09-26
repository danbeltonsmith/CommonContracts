namespace CommonContracts.Jobs
{
    public sealed record CostAccrualRequest
    {
        public long? ID { get; init; }
        public required long AccrualTypeID { get; init; }
        public required decimal Amount { get; init; }
    }
}
