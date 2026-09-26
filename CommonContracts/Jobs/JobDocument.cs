using CommonContracts.Shared;

namespace CommonContracts.Jobs
{
    public sealed record JobDocument
    {
        public required long ID { get; init; }
        public required string OriginalFileName { get; init; }
        public required string ContentType { get; init; }
        public required long FileSizeBytes { get; init; }
        public required AuditUser CreatedBy { get; init; }
        public required DateTimeOffset CreatedDate { get; init; }
    }
}
