namespace CommonContracts.Movements.Patches
{
    public sealed record EscortsPatchRequest
    {
        public required byte InternalPilotEscorts { get; init; }
        public required byte ExternalPilotEscorts { get; init; }
        public required byte PoliceEscorts { get; init; }
        public required byte HighLoadEscorts { get; init; }
        public required byte[] RowVersion { get; init; }
    }
}
