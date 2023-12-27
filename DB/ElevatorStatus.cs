namespace DB
{
    public class ElevatorStatus
    {
        public int CurrentFloor { get; set; }
        public List<int> PendingFloors { get; set; } = new List<int>();
    }
}