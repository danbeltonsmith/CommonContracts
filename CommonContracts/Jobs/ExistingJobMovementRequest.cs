namespace CommonContracts.Jobs
{
    public sealed record ExistingJobMovementRequest : JobMovementRequest
    {
        public required long ID { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
