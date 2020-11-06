using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace My_Console_Text
{
    public class MyConsole
    {
        private readonly BaseCommand[] _avalaibleCommands = { new ChangeDirectoryCommand(), new ListDirectoryCommand(), new ColorCommand(), new FGColorCommand(), new BGColorCommand(),new ClearCommand(), new PwdCommand()};
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
                    return;
                }
            }
            RedirectionSystemMethod(userEntry);
        }

        public void RedirectionSystemMethod(string[] userEntry)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            if (userEntry.Length >= 2)
            {
                for (int i = 1; i < userEntry.Length; i++)
                {
                    userEntry[0] = userEntry[0] + " " + userEntry[i];
                }
            }
            process.StartInfo.Arguments = "/C " + userEntry[0]; //+" "+ userEntry[1]; // Commande à exécuter
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.Close();
        }

        public String[] Prompt()
        {
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            return Console.ReadLine().Split();
        }
    }
}
