namespace CommonContracts.Movements
{
    [Obsolete("Replaced by CommonContracts.Shared.LookupValue. Removed in EA-52 once the Enterprise API maps movements onto the shared shapes.")]
    public sealed record MovementStatusContract
    {
        public required long ID { get; init; }
        public required string Status { get; init; }
    }
}
