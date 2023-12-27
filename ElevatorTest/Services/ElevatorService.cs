using DB;
using ElevatorApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ElevatorService : IElevatorService
{
    private int _currentFloor;
    private List<ElevatorRequest> _internalRequests = new List<ElevatorRequest>();
    private List<ElevatorRequest> _externalRequests = new List<ElevatorRequest>();
    private bool _isMoving = false;

    public ElevatorStatus GetElevatorStatus()
    {
        return new ElevatorStatus
        {
            CurrentFloor = _currentFloor,
            PendingFloors = _internalRequests.Concat(_externalRequests)
                                             .OrderBy(r => r.RequestingFloor)
                                             .ThenBy(r => r.RequestedFloor)
                                             .Select(r => r.RequestedFloor)
                                             .ToList()
        };
    }

    public string MoveInside(int requestedFloorInside)
    {
        if (requestedFloorInside >= 0)
        {
            _internalRequests.Add(new ElevatorRequest { RequestedFloor = requestedFloorInside });
            MoveElevator();
            return $"Moving to floor {requestedFloorInside} inside the elevator...";
        }
        else
        {
            return "Invalid floor.";
        }
    }

    public string CallFromFloor(int requestingFloorOutside)
    {
        if (requestingFloorOutside >= 0)
        {
            _externalRequests.Add(new ElevatorRequest { RequestingFloor = requestingFloorOutside, RequestedFloor = requestingFloorOutside });
            MoveElevator();
            return $"Calling elevator from floor {requestingFloorOutside}...";
        }
        else
        {
            return "Invalid floor.";
        }
    }

    private void MoveElevator()
    {
        if (!_isMoving)
        {
            _isMoving = true;

            var sortedInternalRequests = _internalRequests.OrderBy(r => r.RequestedFloor).ToList();
            var sortedExternalRequests = _externalRequests.OrderBy(r => r.RequestingFloor).ThenBy(r => r.RequestedFloor).ToList();

            var sortedRequests = sortedInternalRequests.Concat(sortedExternalRequests).ToList();

            foreach (var request in sortedRequests)
            {
                MoveToFloor(request.RequestingFloor);
                MoveToFloor(request.RequestedFloor);

                _currentFloor = request.RequestedFloor;              
            }

            _internalRequests.Clear();
            _externalRequests.Clear();
            _isMoving = false;
        }
    }

    private void MoveToFloor(int targetFloor)
    {
        if (targetFloor >= 0 && targetFloor != _currentFloor)
        {
            Console.WriteLine($"Moving to floor {targetFloor}...");
            Thread.Sleep(1000); 
        }
        else if (targetFloor < 0)
        {
            Console.WriteLine("Invalid floor.");
        }
    }
}
