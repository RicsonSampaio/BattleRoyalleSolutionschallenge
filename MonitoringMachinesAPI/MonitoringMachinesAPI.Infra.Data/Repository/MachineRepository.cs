using Microsoft.EntityFrameworkCore;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitoringMachinesAPI.Infra.Data.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly DataContext _context;
        public MachineRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Machine> GetAllMachines()
        {
            try
            {
                return _context.Machines.Include(a => a.Antivirus).Include(h => h.HardDrive).ToList();
            }
            catch (Exception ex)
            {
                Log.Information($"GetAllMachines Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }

        public void ToggleMachine(int machineId)
        {
            try
            {
                var machine = _context.Machines.FirstOrDefault(m => m.Id == machineId);
                if (machine != null)
                {
                    machine.IsUp = !machine.IsUp;
                    Log.Information($"Maquina de id {machine.Id} agora está {machine.IsUp}");
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Information($"GetAllMachines Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }
    }
}
