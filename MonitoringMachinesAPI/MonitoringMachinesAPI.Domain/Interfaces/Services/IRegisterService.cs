using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Domain.Interfaces
{
    public interface IRegisterService
    {
        Machine RegisterLocalMachine();
        Machine RegisterNewMachine();
        Machine DeleteMachineRegistered(int machineId);
    }
}
