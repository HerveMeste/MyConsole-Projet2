using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace My_Console_Text
{
    public class CommandFactory
    {
        private static readonly BaseCommand[] _availableCommands = { new ColorCommand(),
                                                                     new ChangeDirectoryCommand(), 
                                                                     new ListDirectoryCommand(), 
                                                                     new FGColorCommand(), 
                                                                     new BGColorCommand(), 
                                                                     new PwdCommand(), 
                                                                     new ExitCommand() };
                                                                      
        public static BaseCommand Create(String commandLine)
        {
            IList<String> commandParts = commandLine.Split();
            BaseCommand resultingCommand = _availableCommands.FirstOrDefault((command) => command.Commands == commandParts[0]);
            if (resultingCommand is null)
            {
                resultingCommand = new RedirectionSystemCommand { Arguments = commandParts };
            }
            else
            {
                resultingCommand.Arguments = commandParts.Skip(1).ToList();
            }
            return resultingCommand;
        }
    }
}
