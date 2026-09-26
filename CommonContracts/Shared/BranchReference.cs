namespace CommonContracts.Shared
{
    public sealed record BranchReference
    {
        public required long ID { get; init; }
        public required string Name { get; init; }
    }
}
