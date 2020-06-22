using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Domain.Interfaces
{
    public interface ICommandService
    {
        string ExecuteCommand(Command command);
    }
}
