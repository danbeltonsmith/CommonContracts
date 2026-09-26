namespace CommonContracts.Shared
{
    public sealed record LookupValue
    {
        public required long ID { get; init; }
        public required string Name { get; init; }
    }
}
