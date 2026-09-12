namespace CommonContracts.Movements
{
    public sealed record NextMovementNumberResponse
    {
        public required string MovementNumber { get; init; }
    }
}
