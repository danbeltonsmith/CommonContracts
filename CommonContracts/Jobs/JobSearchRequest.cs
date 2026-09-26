using CommonContracts.Shared;

namespace CommonContracts.Jobs
{
    public sealed record JobSearchRequest : PagedSearchRequest
    {
        public string[]? JobNumbers { get; init; }
        public DateTimeOffset? FromDate { get; init; }
        public DateTimeOffset? ToDate { get; init; }
    }
}
