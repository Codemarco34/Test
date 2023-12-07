namespace Entities.Exceptions;

public sealed class MaintenanceNotFoundException : NotFoundException
{
    public MaintenanceNotFoundException(int id) : base($"The Maintenance id:{id} could not found")
    {
    }
}