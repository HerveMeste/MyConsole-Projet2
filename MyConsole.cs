using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace My_Console_Text
{
    public class MyConsole
    {
        private readonly BaseCommand[] _avalaibleCommands = { new ChangeDirectoryCommand(), new ListDirectoryCommand(), new ColorCommand() };
        List<string> history = new List<string>();

        public void Run()
        {
            String[] userEntry = Prompt();
            history.Add(userEntry[0]);
            foreach (BaseCommand command in _avalaibleCommands)
            {
                if (command.Name == userEntry[0])
                {
                    command.Execute(userEntry);
                }
            }
        }

        public String[] Prompt()
        {
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            return Console.ReadLine().Split();
        }
    }
}
