namespace CommonContracts.Movements
{
    public sealed record Movement
    {
        public required long ID { get; init; }
        public required string MovementNumber { get; init; }
        public long? JobID { get; init; }
        public required DateTimeOffset Date { get; init; }
        public required MovementStatusContract Status { get; init; }
        public required MovementLocation Origin { get; init; }
        public required MovementLocation Destination { get; init; }
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
        public decimal? FuelLevyAmount { get; init; }
        public long? OperatorID { get; init; }
        public long? PrimeMoverID { get; init; }
        public long? DollyID { get; init; }
        public long? TrailerID { get; init; }
        public long? SubcontractorID { get; init; }
        public decimal? SubcontractorCostAmount { get; init; }
        public required byte InternalPilotEscorts { get; init; }
        public required byte ExternalPilotEscorts { get; init; }
        public required byte PoliceEscorts { get; init; }
        public required byte HighLoadEscorts { get; init; }
        public required bool Active { get; init; }
        public required MovementAuditUser CreatedBy { get; init; }
        public required DateTimeOffset CreatedDate { get; init; }
        public MovementAuditUser? ModifiedBy { get; init; }
        public DateTimeOffset? ModifiedDate { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
