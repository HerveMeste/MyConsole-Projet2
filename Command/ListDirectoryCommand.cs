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

        private String Path { 
            get
            {
                String path = Directory.GetCurrentDirectory();
                if (Arguments.Count > 0)
                {
                    path = Arguments[0];
                }
                return path;
            }
        }

        public override void Execute()
        {
            IEnumerable<string> listDirectory = Directory.EnumerateDirectories(Path);
            IEnumerable<string> listFiles = Directory.EnumerateFiles(Path);
            IEnumerable<string> listDirFiles = listDirectory.Concat(listFiles);
            PrintFileDirectoryDate(listDirFiles);
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