using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Domain.Interfaces.Repositories
{
    public interface ICommandRepository
    {
        string ExecuteCommand(Command command);
    }
}
