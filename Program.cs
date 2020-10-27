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
            Console.BackgroundColor = ConsoleColor.Green;
            MyConsole console = new MyConsole();
            console.Run();
        }
    }
    public class MyConsole
    {
        List<string> history = new List<string>();
        private String _currentDirectory = "C:\\Users";
        public void Run()
        {
            
            while(true)
            {
                String command = Prompt();
                history.Add(command);
                string[] commandSplit = command.Split();
                if (command == "cd ..")
                {
                    ChangeDirectory(_currentDirectory);// Revien au repertoire parents
                }
                else if (commandSplit[0] == "cd")
                {
                    ChangeDirectoryCd(_currentDirectory, command); // Ouvre un dossier ou affiche le chemin actuel
                }
                else if (commandSplit[0] == "dir")
                {
                    if (command == "dir")
                    {                        
                       ListDirectory(_currentDirectory); //Affiche uniquement les dossiers
                    }
                    else if(command == "dir /l")
                    {                        
                        ListFiles(_currentDirectory); // Affiche uniquement les fichiers
                    }
                    else if ( command.Length >= 6 && command.Substring(0,6) == "dir /t")// commence
                    {
                        Alphabetique(_currentDirectory, command.Substring(7));// commence a partir du 7eme charatere
                    }
                }
                else if (command == "history")
                {
                    Console.WriteLine(String.Join("\n", history));
                }
                else if (command == "cls-history")
                {
                    history.Clear();
                }
                else if (command == "cls")
                {
                    Console.Clear();
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
            foreach (string item in listedDirectories)
            {
                DateTime date = Directory.GetCreationTime(item);
                Console.WriteLine(date + " " + item);
            }
        }

        public void ListFiles(String directoryPath)
        {
            IEnumerable<String> listedFiles = Directory.EnumerateFiles(directoryPath);
            foreach (string item in listedFiles)
            {
                DateTime date = Directory.GetCreationTime(item);
                Console.WriteLine(date + " " + item);
            }
        }
        public static void Alphabetique(string path, string searchPattern)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path, searchPattern);
                Console.WriteLine("The number of directories starting with {0} is {1}.", searchPattern, dirs.Length);
                Console.WriteLine(String.Join('\n', dirs));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
