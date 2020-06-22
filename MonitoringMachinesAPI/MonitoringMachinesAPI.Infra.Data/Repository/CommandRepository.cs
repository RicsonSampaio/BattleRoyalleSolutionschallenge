using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;

namespace MonitoringMachinesAPI.Infra.Data.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private readonly DataContext _context;
        public CommandRepository(DataContext context)
        {
            _context = context;
        }

        public string ExecuteCommand(Command command)
        {
            Log.Information($"ExecuteCommand repositorio");
            try
            {
                var machine = _context.Machines.FirstOrDefault(m => m.Id == command.MachineId);
                if (machine == null)
                {
                    Log.Information($"Cannot run {command.CMDCommand} by Machine: {command.MachineId}. this machine does not exists");
                    return $"Cannot run {command.CMDCommand} by Machine: {command.MachineId}. this machine does not exists";
                }
                if (machine.IsUp)
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.Verb = "runas";
                    cmd.Start();

                    cmd.StandardInput.WriteLine(command.CMDCommand);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();

                    var commandResult = cmd.StandardOutput.ReadToEnd();
                    
                    Log.Information($"Command written: {command.CMDCommand} by Machine: {command.MachineId} | Command Result: {commandResult} ");
                    return commandResult;
                }
                else
                {
                    Log.Information($"Cannot run {command.CMDCommand} by Machine: {command.MachineId}. This machine is off");
                    return $"Cannot run {command.CMDCommand} by Machine: {command.MachineId}. This machine is off";
                }
            }
            catch (Exception ex)
            {
                Log.Information($"ExecuteCommand Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }
    }
}
