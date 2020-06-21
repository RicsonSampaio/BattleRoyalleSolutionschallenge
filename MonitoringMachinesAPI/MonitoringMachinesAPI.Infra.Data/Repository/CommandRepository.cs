using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
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
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();

                return cmd.StandardOutput.ReadToEnd();
            }
            else
            {
                return "This Machine is off";
            }
            
        }
    }
}
