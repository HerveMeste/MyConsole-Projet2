using System;
using System.IO;

namespace My_Console_Text
{
    class Program 
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsolePrompt prompt = new ConsolePrompt();
                String commandText = PromptLine();
                BaseCommand command = CommandFactory.Create(commandText);
                command.Execute();
            }
        }

        static String PromptLine()
        {
            Console.Write(Directory.GetCurrentDirectory() + "> ");
            String line = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(line))
            {
                return PromptLine();
            }
            return line;
        }
    }
}