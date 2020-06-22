using MonitoringMachinesAPI.Domain.Models;
using System.Collections.Generic;

namespace MonitoringMachinesAPI.Domain.Interfaces
{
    public interface IMachineService
    {
        IEnumerable<Machine> GetAllMachines();
        void ToggleMachine(int machineId);
    }
}
