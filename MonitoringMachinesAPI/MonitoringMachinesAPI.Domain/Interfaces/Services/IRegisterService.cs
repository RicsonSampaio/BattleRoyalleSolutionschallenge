using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Domain.Interfaces
{
    public interface IRegisterService
    {
        Machine RegisterLocalMachine();
        Machine RegisterNewMachine(); // verificar se ja nao tem la
        Machine DeleteMachineRegistered(int machineId);
    }
}
