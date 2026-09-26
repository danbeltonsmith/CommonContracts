using CommonContracts.Movements;

namespace CommonContracts.Jobs
{
    public sealed record JobSaveConflictResponse
    {
        public List<Movement> CurrentMovements { get; init; } = [];
    }
}
