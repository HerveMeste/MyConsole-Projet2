using System;
using System.Collections.Generic;
using System.IO;

namespace My_Console_Text
{
    public class ListDirectoryCommand : BaseCommand
    {
        public override string Name => "dir";

        public override void Execute(string[] fullCommand)
        {
            if (fullCommand.Length == 1)
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                int i = 0;
                int j = 0;
                IEnumerable<String> listDirectory = Directory.EnumerateDirectories(Directory.GetCurrentDirectory());
                IEnumerable<String> listFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
                foreach (string item in listDirectory)
                {
                    string[] path = item.Split("\\");
                    i++;
                    string last = path[path.Length - 1];
                    DateTime date = Directory.GetCreationTime(item);
                    Console.WriteLine(date + "     <DIR>     " + last);
                }
                foreach (string item in listFiles)
                {
                    string[] path = item.Split("\\");
                    j++;
                    string last = path[path.Length - 1];
                    DateTime date = Directory.GetCreationTime(item);
                    Console.WriteLine(date + "               " + last);
                }
                Console.WriteLine("il y a : " + i + " dossiers et " + j + " fichiers");

            }
            if (fullCommand.Length == 3 && fullCommand[1] == "/t")
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory(), fullCommand[2]);
                    Console.WriteLine("The number of directories starting with {0} is {1}.", fullCommand[2], dirs.Length);
                    foreach (string dir in dirs)
                    {
                        Console.WriteLine(dir);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }

        }
    }
}