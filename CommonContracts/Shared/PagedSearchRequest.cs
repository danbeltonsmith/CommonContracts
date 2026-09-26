namespace CommonContracts.Shared
{
    public abstract record PagedSearchRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 25;
        public string? SearchValue { get; init; }
    }
}
