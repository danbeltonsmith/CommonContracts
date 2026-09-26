namespace CommonContracts.Movements
{
    [Obsolete("Replaced by CommonContracts.Shared.AuditUser. Removed in EA-52 once the Enterprise API maps movements onto the shared shapes.")]
    public sealed record MovementAuditUser
    {
        public required long ID { get; init; }
        public required string DisplayName { get; init; }
    }
}
