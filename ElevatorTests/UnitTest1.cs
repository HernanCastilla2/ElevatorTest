[TestFixture]
public class ElevatorServiceTests
{
    [Test]
    public void MoveInside_ValidFloor_ShouldAddInternalRequestAndMoveElevator()
    {
        
        var elevatorService = new ElevatorService();
        
        var result = elevatorService.MoveInside(3);
        
        Assert.That(result, Is.EqualTo("Moving to floor 3 inside the elevator..."));
        
    }

    [Test]
    public void MoveInside_InvalidFloor_ShouldReturnErrorMessage()
    {
        
        var elevatorService = new ElevatorService();
                
        var result = elevatorService.MoveInside(-1);
                
        Assert.That(result, Is.EqualTo("Invalid floor."));
        Assert.That(elevatorService.GetElevatorStatus().PendingFloors.Count, Is.EqualTo(0));
    }

    [Test]
    public void CallFromFloor_ValidFloor_ShouldAddExternalRequestAndMoveElevator()
    {
        
        var elevatorService = new ElevatorService();

        var result = elevatorService.CallFromFloor(5);
                
        Assert.That(result, Is.EqualTo("Calling elevator from floor 5..."));        
    }

    [Test]
    public void CallFromFloor_InvalidFloor_ShouldReturnErrorMessage()
    {
        
        var elevatorService = new ElevatorService();

        var result = elevatorService.CallFromFloor(-1);

        Assert.That(result, Is.EqualTo("Invalid floor."));
        
    }
}
