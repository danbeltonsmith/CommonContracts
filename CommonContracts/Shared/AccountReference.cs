namespace CommonContracts.Shared
{
    public sealed record AccountReference
    {
        public required long ID { get; init; }
        public required string Name { get; init; }
    }
}
