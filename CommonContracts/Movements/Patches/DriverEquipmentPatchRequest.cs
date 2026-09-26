namespace CommonContracts.Movements.Patches
{
    public sealed record DriverEquipmentPatchRequest
    {
        public long? OperatorID { get; init; }
        public long? PrimeMoverID { get; init; }
        public long? DollyID { get; init; }
        public long? TrailerID { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
