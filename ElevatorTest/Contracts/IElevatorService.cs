using DB;

namespace ElevatorApi.Contracts
{
    public interface IElevatorService
    {
        ElevatorStatus GetElevatorStatus();
        string MoveInside(int requestedFloorInside);
        string CallFromFloor(int requestingFloorOutside);
    }
}
