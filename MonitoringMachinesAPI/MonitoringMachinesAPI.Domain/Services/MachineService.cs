using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            Log.Information("GetAllMachinesService");
            return _machineRepository.GetAllMachines();
        }

        public void ToggleMachine(int machineId)
        {
            _machineRepository.ToggleMachine(machineId);
        }
    }
}
