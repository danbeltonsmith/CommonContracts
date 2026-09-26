namespace CommonContracts.Movements
{
    [Obsolete("Replaced by PagedResult<MovementSummary>. Removed in EA-52 once the Enterprise API maps movements onto the shared shapes.")]
    public sealed record MovementSearchResponse
    {
        public List<MovementSummary> Items { get; init; } = [];
        public required int PageNumber { get; init; }
        public required int PageSize { get; init; }
        public required int TotalCount { get; init; }
        public required int TotalPages { get; init; }
    }
}
