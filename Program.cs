using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
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
        private String _currentDirectory = "C:\\Users";
        public void Run()
        {
            
            while(true)
            {
                String command = Prompt();
                               
                if (command == "cd ..")
                {
                    ChangeDirectory(_currentDirectory);// Revien au repertoire parents
                }
                else if (command.Length >= 2 && command.Substring(0,2) == "cd")
                {
                    ChangeDirectoryCd(_currentDirectory, command); // Ouvre un dossier ou affiche le chemin actuel
                }
                else if (command.Substring(0,3) == "dir" && command.Length >= 3)
                {
                    if (command == "dir")
                    {                        
                        ListDirectory(_currentDirectory);// Affiche uniquement les dossiers
                    }
                    else if(command == "dir /l")
                    {                        
                        ListFiles(_currentDirectory); // Affiche uniquement les fichiers
                    }
                    else if(command.Substring(0,6) == "dir /t" && command.Length >= 6)
                    {
                        Alphabetique(_currentDirectory, command.Substring(7));
                    }
                }              
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(command + " n’est pas reconnu en tant que commande interne \nou externe, un programme exécutable ou un fichier de commandes.");
                }
            }
        }

        public String Prompt()
        {
            Console.Write(_currentDirectory + "> ");
            String command = Console.ReadLine();
            return command;

        }

        public void ChangeDirectoryCd(String newPath, string command)
        {
            string chem;
            if (command == "cd")
            {
                Console.WriteLine(_currentDirectory);
                return;
            }
            else if (_currentDirectory == "C:\\")
            {
                chem = _currentDirectory + command.Substring(3);
            }
            else
            {            
                chem = _currentDirectory + "\\" + command.Substring(3);
            }
            string[] tabfichier = Directory.GetFileSystemEntries(_currentDirectory);
            for (int i = 0; i < tabfichier.Length; i++)
            {
                if (tabfichier[i] == chem)
                {
                    if(_currentDirectory == "C:\\")
                    {
                        
                        newPath = _currentDirectory + command.Substring(3);
                        _currentDirectory = newPath;
                        
                        return;
                    }
                    else
                    {
                        newPath = _currentDirectory + "\\" + command.Substring(3);
                        _currentDirectory = newPath;
                        return;
                    }
                }
            }
            Console.WriteLine("repertoire inexistant");
        }

        public void ChangeDirectory(String newPath)
        {
            try
            {               
                string parent = Directory.GetParent(newPath).FullName;
                _currentDirectory = parent;
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, or " +
                    "contains invalid characters.");
            }

        }

        public void ListDirectory(String directoryPath)
        {
            IEnumerable<String> listedDirectories = Directory.EnumerateDirectories(directoryPath);
            Console.WriteLine("{0}\n", String.Join("\n", listedDirectories));
        }

        public void ListFiles(String directoryPath)
        {
            IEnumerable<String> listedFiles = Directory.EnumerateFiles(directoryPath);
            DateTime date = File.GetCreationTime(directoryPath);
            Console.WriteLine("{0} \n", String.Join("\n", listedFiles, date));           
        }

        static void DisplayFileSystemInfoAttributes(FileSystemInfo fsi)
        {
            //Assume that this entry is a file.
            //string entryType = "File";

           // Determine if entry is really a directory
           // if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
           //{
             //   entryType = "Directory";
            //}
            // Show this entry's type, name, and creation date.

            Console.WriteLine("{0}", fsi.CreationTime);
        }
        public static void Alphabetique(string path, string searchPattern)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path, searchPattern);
                Console.WriteLine("The number of directories starting with {0} is {1}.",searchPattern,  dirs.Length);

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
