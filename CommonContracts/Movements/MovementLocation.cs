namespace CommonContracts.Movements
{
    public sealed record MovementLocation
    {
        public required long ID { get; init; }
        public required string Name { get; init; }
        public string? Suburb { get; init; }
        public string? StateCode { get; init; }
        public required string CountryCode { get; init; }
    }
}
