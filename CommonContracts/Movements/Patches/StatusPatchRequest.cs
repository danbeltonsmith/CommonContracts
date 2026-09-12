namespace CommonContracts.Movements.Patches
{
    public sealed record StatusPatchRequest
    {
        public required long StatusID { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
