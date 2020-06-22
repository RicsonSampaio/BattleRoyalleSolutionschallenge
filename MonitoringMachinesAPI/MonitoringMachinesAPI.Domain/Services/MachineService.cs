using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using System.Collections.Generic;

namespace MonitoringMachinesAPI.Domain.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public IEnumerable<Machine> GetAllMachines()
        {
            return _machineRepository.GetAllMachines();
        }

        public void ToggleMachine(int machineId)
        {
            _machineRepository.ToggleMachine(machineId);
        }
    }
}
