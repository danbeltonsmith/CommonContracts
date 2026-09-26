namespace CommonContracts.Movements.Patches
{
    public sealed record ChargePatchRequest
    {
        public decimal? ChargeAmount { get; init; }
        public decimal? FuelLevyPercentage { get; init; }
        public decimal? SubcontractorCostAmount { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
