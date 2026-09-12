namespace CommonContracts.Movements.Patches
{
    public sealed record DimensionsPatchRequest
    {
        public decimal? Length { get; init; }
        public decimal? Width { get; init; }
        public decimal? Height { get; init; }
        public decimal? Weight { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
