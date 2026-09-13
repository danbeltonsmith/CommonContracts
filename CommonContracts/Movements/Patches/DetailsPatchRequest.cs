namespace CommonContracts.Movements.Patches
{
    public sealed record DetailsPatchRequest
    {
        public string? PermitDetail { get; init; }
        public string? Description { get; init; }
        public string? Notes { get; init; }
        public string? Vessel { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
