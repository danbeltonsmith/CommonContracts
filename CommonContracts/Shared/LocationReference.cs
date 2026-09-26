namespace CommonContracts.Shared
{
    public sealed record LocationReference
    {
        public required long ID { get; init; }
        public required string Name { get; init; }
        public required string DisplayName { get; init; }
        public string? Suburb { get; init; }
        public string? StateCode { get; init; }
        public required string CountryCode { get; init; }
    }
}
