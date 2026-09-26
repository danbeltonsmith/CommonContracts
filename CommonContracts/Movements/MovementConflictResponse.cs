namespace CommonContracts.Movements
{
    public sealed record MovementConflictResponse
    {
        public required Movement CurrentMovement { get; init; }
    }
}
