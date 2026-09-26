namespace CommonContracts.Movements
{
    public sealed record MovementStatusContract
    {
        public required long ID { get; init; }
        public required string Status { get; init; }
    }
}
