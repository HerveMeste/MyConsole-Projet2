using System;
using System.Collections.Generic;
using System.IO;

namespace My_Console_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConsole console = new MyConsole();
            console.Run();
        }
    }
    public class MyConsole
    {
        private String _currentDirectory = "C:\\";

        public void Run()
        {
            while (true)
            {
                String command = Prompt();
                if (command == "cd")
                {
                    ChangeDirectory( _currentDirectory/* fournir l'argument de cd */);
                }
                else if (command == "dir")
                { 
                    ListDirectory(_currentDirectory  /*fournir l'argument de dir, si il n'y en a pas, c'est _currentDirectory */);
                    
                }
            }
        }

        public String Prompt()
        {
            Console.Write(_currentDirectory + "> ");
            String command = Console.ReadLine();
            return command;
        }

        public void ChangeDirectory(String newPath)
        {
            _currentDirectory = newPath;
        }

        public void ListDirectory(String directoryPath)
        {
            IEnumerable<String> listedFiles = Directory.EnumerateFiles(directoryPath);
            IEnumerable<String> listedDirectories = Directory.EnumerateDirectories(directoryPath);
            Console.WriteLine("{0} {1}", String.Join("\n", listedFiles), String.Join("\n", listedDirectories));
        }
    }

    /*
    public abstract class Command // classe mere 
    {
        public abstract string Command(string x);
    }
    class Dir : Command
    {
        public override string Command(string x)
        {
            return null;
        }
    }*/
    
}
