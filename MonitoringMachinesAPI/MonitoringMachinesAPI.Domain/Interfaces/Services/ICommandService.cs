﻿using MonitoringMachinesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringMachinesAPI.Domain.Interfaces
{
    public interface ICommandService
    {
        string ExecuteCommand(Command command);
    }
}