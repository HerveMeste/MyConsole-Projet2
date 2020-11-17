using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace My_Console_Text
{
    class PromptMethode
    {
        public FullCommand Prompt()
        {
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            string line = Console.ReadLine();
            int spacePosition = line.IndexOf(" ");
            if (spacePosition == -1)
            {
                string command = line;
                string argument = "";
                Console.WriteLine(command);
                Console.WriteLine(argument);
                return new FullCommand(command, argument);

            }
            else
            {
                string command = line.Substring(0, spacePosition);
                string argument = line.Substring(spacePosition + 1);
                Console.WriteLine(command);
                Console.WriteLine(argument);
                return new FullCommand(command, argument);
            }
        }
    }
}
