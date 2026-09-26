namespace CommonContracts.Movements
{
    public sealed record MovementAuditUser
    {
        public required long ID { get; init; }
        public required string DisplayName { get; init; }
    }
}
