namespace CommonContracts.Shared
{
    public sealed record AuditUser
    {
        public required long ID { get; init; }
        public required string DisplayName { get; init; }
    }
}
