﻿using MonitoringMachinesAPI.Domain.Models;
using System.Collections.Generic;

namespace MonitoringMachinesAPI.Domain.Interfaces.Repositories
{
    public interface IMachineRepository
    {
        IEnumerable<Machine> GetAllMachines();
        void ToggleMachine(int machineId);
    }
}
