namespace CommonContracts.Movements.Patches
{
    public sealed record SchedulePatchRequest
    {
        public required DateTimeOffset Date { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
