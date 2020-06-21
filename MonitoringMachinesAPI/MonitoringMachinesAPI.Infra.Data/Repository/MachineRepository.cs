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
            Log.Information("GetAllMachinesService");
            try
            {
                return _context.Machines
                .Include(x => x.Antivirus)
                .Include(x => x.HardDrive)
                .ToList();
            }
            catch (Exception ex)
            {
                Log.Information("GetAllMachinesService");
                throw;
            }
            
        }

        public void ToggleMachine(int machineId)
        {
            var machine = _context.Machines.FirstOrDefault(m => m.Id == machineId);

            if (machine != null)
            {
                machine.IsUp = !machine.IsUp;
                _context.SaveChanges();
            }
        }
    }
}
