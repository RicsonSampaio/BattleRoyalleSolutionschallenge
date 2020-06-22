using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using Serilog;
using System;
using System.Diagnostics;

namespace MonitoringMachinesAPI.Infra.Data.Repository
{
    public class CommandRepository : ICommandRepository
    {
        public string ExecuteCommand(Command command)
        {
            try
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
            catch (Exception ex)
            {
                Log.Information($"ExecuteCommand Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }
    }
}
