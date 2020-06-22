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
            try
            {
                var machine = _context.Machines.FirstOrDefault(m => m.Id == command.MachineId);
                if (machine.IsUp)
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine(command.CMDCommand);
                    Log.Information($"Command written: {command.CMDCommand} by Machine: {command.MachineId}");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();

                    var commandResult = cmd.StandardOutput.ReadToEnd();
                    
                    Log.Information($"Command Result: {commandResult} Command written: {command.CMDCommand} by Machine: {command.MachineId}");
                    return commandResult;
                }
                else
                {
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
