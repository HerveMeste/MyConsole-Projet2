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
            IEnumerable<string> listDirectory = Directory.EnumerateDirectories(Directory.GetCurrentDirectory());
            IEnumerable<string> listFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
            IEnumerable<string> listDirFiles = listDirectory.Concat(listFiles);
            if (fullCommand.Length == 1)
            {
                PrintFileDirectoryDate(listDirFiles);
            }
            if (fullCommand.Length == 3 && fullCommand[1] == "/t")
            {
                IEnumerable<string> listDirectorySort = Directory.EnumerateDirectories(Directory.GetCurrentDirectory(), fullCommand[2]);
                IEnumerable<string> listFilesSort = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), fullCommand[2]);
                IEnumerable<string> listDirFilesSort = listDirectorySort.Concat(listFilesSort);
                PrintFileDirectoryDate(listDirFilesSort);
            }
        }
        public void PrintFileDirectoryDate(IEnumerable<string> tableau)
        {
            foreach (string element in tableau)
            {
                string[] path = element.Split("\\");
                IEnumerable<String> result = path.TakeLast(1);
                DateTime date = Directory.GetCreationTime(element);
                Console.WriteLine(date + "          " + String.Join("", result));
            }
        }
    }
}