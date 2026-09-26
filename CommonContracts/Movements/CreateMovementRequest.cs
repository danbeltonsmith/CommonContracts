namespace CommonContracts.Movements
{
    public sealed record CreateMovementRequest
    {
        public required string MovementNumber { get; init; }
        public long? JobID { get; init; }
        public required DateTimeOffset Date { get; init; }
        public required long StatusID { get; init; }
        public required long OriginLocationID { get; init; }
        public required long DestinationLocationID { get; init; }
        public string? PermitDetail { get; init; }
        public string? Description { get; init; }
        public string? Notes { get; init; }
        public string? Vessel { get; init; }
        public decimal? Length { get; init; }
        public decimal? Width { get; init; }
        public decimal? Height { get; init; }
        public decimal? Weight { get; init; }
        public decimal? ChargeAmount { get; init; }
        public decimal? FuelLevyPercentage { get; init; }
        public long? OperatorID { get; init; }
        public long? PrimeMoverID { get; init; }
        public long? DollyID { get; init; }
        public long? TrailerID { get; init; }
        public long? SubcontractorID { get; init; }
        public decimal? SubcontractorCostAmount { get; init; }
        public byte InternalPilotEscorts { get; init; }
        public byte ExternalPilotEscorts { get; init; }
        public byte PoliceEscorts { get; init; }
        public byte HighLoadEscorts { get; init; }
    }
}
