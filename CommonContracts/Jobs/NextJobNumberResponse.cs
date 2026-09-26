namespace CommonContracts.Jobs
{
    public sealed record NextJobNumberResponse
    {
        public required string JobNumber { get; init; }
    }
}
