namespace CommonContracts.Movements
{
    public sealed record MovementSummary
    {
        public required long ID { get; init; }
        public required string MovementNumber { get; init; }
        public long? JobID { get; init; }
        public required DateTimeOffset Date { get; init; }
        public required MovementStatusContract Status { get; init; }
        public required MovementLocation Origin { get; init; }
        public required MovementLocation Destination { get; init; }
        public decimal? ChargeAmount { get; init; }
        public decimal? FuelLevyPercentage { get; init; }
        public decimal? FuelLevyAmount { get; init; }
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
