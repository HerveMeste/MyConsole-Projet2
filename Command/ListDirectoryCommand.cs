using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

namespace My_Console_Text
{
    public class ListDirectoryCommand : BaseCommand
    {
        public override string Commands => "dir";
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
            if (Arguments.Count == 2 && Arguments[0] == "/t")
            {
                IEnumerable<string> dirs = Directory.GetDirectories(Directory.GetCurrentDirectory(), Arguments[1]);
                IEnumerable<string> file = Directory.GetFiles(Directory.GetCurrentDirectory(),Arguments[1]);
                IEnumerable<string> listDirFilesSort = dirs.Concat(file);
                Console.WriteLine("Il y a "+listDirFilesSort.Count()+" Dossier / Fichier commencant par " + Arguments[1]);
                PrintFileDirectoryDate(listDirFilesSort);
                return;
            }
            try
            {
                IEnumerable<string> listDirectory = Directory.EnumerateDirectories(Path);
                IEnumerable<string> listFiles = Directory.EnumerateFiles(Path);
                IEnumerable<string> listDirFiles = listDirectory.Concat(listFiles);
                PrintFileDirectoryDate(listDirFiles);
            }
            catch
            {
                Console.WriteLine("Mauvaise commande");
            }
        }

        public void PrintFileDirectoryDate(IEnumerable<string> liste)
        {
            foreach (string element in liste)
            {
                string[] path = element.Split("\\");
                IEnumerable<String> result = path.TakeLast(1);
                DateTime date = Directory.GetCreationTime(element);
                Console.WriteLine(date + "          " + String.Join("", result));
            }
        }
    }
}