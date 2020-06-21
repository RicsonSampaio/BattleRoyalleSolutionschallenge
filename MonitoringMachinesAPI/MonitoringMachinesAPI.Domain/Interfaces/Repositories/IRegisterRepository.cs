using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Domain.Interfaces.Repositories
{
    public interface IRegisterRepository
    {
        Machine RegisterLocalMachine();
        Machine RegisterNewMachine();
        Machine DeleteMachineRegistered(int machineId);
    }
}
