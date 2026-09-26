using CommonContracts.Shared;

namespace CommonContracts.Movements
{
    public sealed record MovementSearchRequest : PagedSearchRequest
    {
        public string[]? MovementNumbers { get; init; }
        public long? JobID { get; init; }
        public long[]? StatusIDs { get; init; }
        public DateTimeOffset? FromDate { get; init; }
        public DateTimeOffset? ToDate { get; init; }
    }
}
