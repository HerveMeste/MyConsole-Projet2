using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace My_Console_Text
{
    public class MyConsole
    {
        private readonly BaseCommand[] _avalaibleCommands = { new ColorCommand(), new ChangeDirectoryCommand(),new ListDirectoryCommand(), new FGColorCommand(), new BGColorCommand(), new ClearCommand(), new PwdCommand(), new ExitCommand() };
        List<string> history = new List<string>();
        
        public void Run()
        {
            PromptMethode prompt = new PromptMethode();
            FullCommand userEntry = prompt.Prompt();           
            foreach (BaseCommand command in _avalaibleCommands)
            {
                if (command.Name == userEntry.command)
                {
                    command.Execute(userEntry);
                    return;
                }
            }
            RedirectionSystemCommand.RedirectionSystemMethod(userEntry);
        }    
    }
}
