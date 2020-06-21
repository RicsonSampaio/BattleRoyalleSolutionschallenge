using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;


namespace MonitoringMachinesAPI.Domain.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommandRepository _commandRepository;
        public CommandService(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public string ExecuteCommand(Command command)
        {
            return _commandRepository.ExecuteCommand(command);
        }
    }
}
