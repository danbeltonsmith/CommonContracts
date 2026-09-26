namespace CommonContracts.Movements.Patches
{
    public sealed record LocationsPatchRequest
    {
        public required long OriginLocationID { get; init; }
        public required long DestinationLocationID { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
