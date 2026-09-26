namespace CommonContracts.Jobs
{
    public sealed record JobDocumentUploadOptions
    {
        public List<string> AllowedExtensions { get; init; } = [];
        public required long MaxFileSizeBytes { get; init; }
    }
}
