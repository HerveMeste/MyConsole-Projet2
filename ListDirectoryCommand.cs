using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

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
                    //string[] path = item.Split("\\");
                    IEnumerable<String> result = listDirectory.TakeLast(1);                  
                    DateTime date = Directory.GetCreationTime(item);
                    Console.WriteLine(date + "     <DIR>     " + String.Join("",result));
                }
                foreach (string item in listFiles)
                {
                    string[] path = item.Split("\\");
                    j++;
                    string last = path[path.Length - 1];
                    DateTime date = Directory.GetCreationTime(item);
                    Console.WriteLine(date + "               " + last);
                }
                Console.WriteLine("il y a : " + listDirectory.Count() + " dossiers et " + listFiles.Count() + " fichiers");

            }
            if (fullCommand.Length == 3 && fullCommand[1] == "/t")
            {
                try
                {
                    string[] directorySort = Directory.GetDirectories(Directory.GetCurrentDirectory(), fullCommand[2]);
                    string[] filesSort = Directory.GetFiles(Directory.GetCurrentDirectory(), fullCommand[2]);
                   
                    foreach (string directory in directorySort)
                    {
                        string[] path = directory.Split("\\");
                        string last = path[path.Length - 1];
                        DateTime date = Directory.GetCreationTime(directory); 
                        Console.WriteLine(date + "     <DIR>     " + last);
                    }
                    foreach (string files in filesSort)
                    {
                        string[] path = files.Split("\\");
                        string last = path[path.Length - 1];
                        DateTime date = Directory.GetCreationTime(files);
                        Console.WriteLine(date + "               " + last);
                    }
                    Console.WriteLine("\nThe number of directories starting with {0} is : {2} \nThe number of files starting with {0} is : {1}.", fullCommand[2], filesSort.Length, directorySort.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }

        }
    }
}