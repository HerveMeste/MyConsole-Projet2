<<<<<<< HEAD
﻿using Microsoft.VisualBasic;using System;using System.Collections.Generic;using System.Data;using System.IO;using System.Runtime.InteropServices;namespace My_Console_Text{    class Program    {        static void Main(string[] args)        {            while (true)            {                MyConsole console = new MyConsole();                console.Run();            }        }    }    public class MyConsole    {        string[] array;
        List<string> history = new List<string>();        private String _currentDirectory = "C:\\Users";        public void Run()        {            while (true)            {                String command = Prompt();                array = command.Split();
                /*Console.WriteLine(String.Join("\n", array));*/
                history.Add(command);                if (command == "cd ..")                {                    ChangeDirectory(_currentDirectory);// Revien au repertoire parents
                }                else if (array[0] == "bc")                {                    ChangeBgColor(command);                }                else if (array[0] == "fc")                {                    ChangeFgColor(command);                }                else if (array[0] == "color")                {                    Color();                }                else if (array[0] == "cd")                {                    ChangeDirectoryCd(_currentDirectory, command); // Ouvre un dossier ou affiche le chemin actuel
                }                else if (array[0] == "dir")                {                    if (command == "dir")                    {                        ListDirectory(_currentDirectory); //Affiche uniquement les dossiers
                    }                    else if (array[1] == "/l")                    {                        ListFiles(_currentDirectory); // Affiche uniquement les fichiers
                    }                    else if (array[1] == "/t" && array.Length == 3)// commence
                    {                        Alphabetique(_currentDirectory, array[2]);// commence a partir du 7eme charatere
                    }                }                else if (command == "history")                {                    Console.WriteLine(String.Join("\n", history));                }                else if (command == "cls-history")                {                    history.Clear();                }                else if (command == "cls")                {                    Console.Clear();                }                else if (command == "exit")                {                    break;                }                else                {                    Console.WriteLine(command + " n’est pas reconnu en tant que commande interne \nou externe, un programme exécutable ou un fichier de commandes.");                }            }        }        public String Prompt()        {            Console.Write(_currentDirectory + "> ");            String command = Console.ReadLine();            return command;        }        public void ChangeDirectoryCd(String newPath, string command)        {            string chem;            if (command == array[0])            {                Console.WriteLine(_currentDirectory);                return;            }            else if (_currentDirectory == "C:\\")            {                chem = _currentDirectory + array[1];            }            else            {                chem = _currentDirectory + "\\" + array[1];            }            string[] tabfichier = Directory.GetFileSystemEntries(_currentDirectory);            for (int i = 0; i < tabfichier.Length; i++)            {                if (tabfichier[i] == chem)                {                    if (_currentDirectory == "C:\\")                    {                        newPath = _currentDirectory + array[1];                        _currentDirectory = newPath;                        return;                    }                    else                    {                        newPath = _currentDirectory + "\\" + array[1];                        _currentDirectory = newPath;                        return;                    }                }            }            Console.WriteLine("repertoire inexistant");        }        public void ChangeDirectory(String newPath)        {            try            {                string parent = Directory.GetParent(newPath).FullName;                _currentDirectory = parent;            }            catch (ArgumentNullException)            {                System.Console.WriteLine("Path is a null reference.");            }            catch (ArgumentException)            {                System.Console.WriteLine("Path is an empty string, " +                    "contains only white spaces, or " +                    "contains invalid characters.");            }        }        public void ListDirectory(String directoryPath)        {            IEnumerable<String> listedDirectories = Directory.EnumerateDirectories(directoryPath);            foreach (string item in listedDirectories)            {                DateTime date = Directory.GetCreationTime(item);                Console.WriteLine(date + " " + item);            }        }        public void ListFiles(String directoryPath)        {            IEnumerable<String> listedFiles = Directory.EnumerateFiles(directoryPath);            foreach (string item in listedFiles)            {                DateTime date = Directory.GetCreationTime(item);                Console.WriteLine(date + " " + item);            }        }        public static void Alphabetique(string path, string searchPattern)        {            try            {                string[] dirs = Directory.GetDirectories(path, searchPattern);                Console.WriteLine("The number of directories starting with {0} is {1}.", searchPattern, dirs.Length);                foreach (string dir in dirs)                {                    Console.WriteLine(dir);                }            }            catch (Exception e)            {                Console.WriteLine("The process failed: {0}", e.ToString());            }        }        public void ChangeBgColor(string command)        {            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));            foreach (var values in colors)            {                if (array[1] == Convert.ToString(values))                {                    Console.BackgroundColor = values;                    Console.Clear();                    return;                }            }            Console.WriteLine("Enter color for see colors ");        }        public void ChangeFgColor(string command)        {            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));            foreach (var values in colors)            {                if (array[1] == Convert.ToString(values))                {                    Console.ForegroundColor = values;                    return;
                }

            }            Console.WriteLine("Enter color for see colors ");        }        public void Color()        {            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));            Console.WriteLine(String.Join("\n", colors));        }    }}
=======
﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        string[] commandSplit;
        List<string> history = new List<string>();
        private String _currentDirectory = "C:\\Users";
        public void Run()
        {

            while (true)
            {
                String command = Prompt();
                commandSplit = command.Split();
                history.Add(command);

                if (command == "cd ..")
                {
                    ChangeDirectory(_currentDirectory); // Revien au repertoire parents
                }
                else if (commandSplit[0] == "cd")
                {
                    ChangeDirectoryCd(_currentDirectory, command); // Ouvre un dossier ou affiche le chemin actuel
                }
                else if (commandSplit[0] == "color")
                {
                    ListeColor();
                }
                else if (commandSplit[0] == "fgcolor")
                {
                    ChangeFgColor(command);
                }
                else if (commandSplit[0] == "bgcolor")
                {
                    ChangeBgColor(command);
                }
                else if (commandSplit[0] == "dir")
                {
                    if (command == "dir")
                    {
                        ListDirectory(_currentDirectory); //Affiche uniquement les dossiers
                    }
                    else if (commandSplit[1] == "/l")
                    {
                        ListFiles(_currentDirectory); // Affiche uniquement les fichiers
                    }
                    else if (commandSplit[1] == "/t" && commandSplit.Length == 3)
                    {
                        Alphabetique(_currentDirectory, commandSplit[2]);
                    }
                    else
                    {
                        Console.WriteLine("mauvaise commande");
                    }
                }
                else if (command == "history")
                {
                    foreach (string item in history)
                    {
                        Console.WriteLine(item);
                    }
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
                chem = _currentDirectory + commandSplit[1];
            }
            else
            {
                chem = _currentDirectory + "\\" + commandSplit[1];
            }

            string[] tabfichier = Directory.GetFileSystemEntries(_currentDirectory);

            for (int i = 0; i < tabfichier.Length; i++)
            {
                if (tabfichier[i] == chem)
                {
                    if (_currentDirectory == "C:\\")
                    {

                        newPath = _currentDirectory + commandSplit[1];
                        _currentDirectory = newPath;
                        return;
                    }
                    else
                    {
                        newPath = _currentDirectory + "\\" + commandSplit[1];
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
        public static void ChangeFgColor(string commande)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            foreach (var color in colors)
            {
                if (Convert.ToString(color) == commande.Substring(8))
                {
                    Console.ForegroundColor = color;
                    return;
                }
            }
            Console.WriteLine("La couleur ou la syntaxe n'existe pas, taper 'color' pour voir la liste des couleurs disponible");
        }
        public static void ListeColor()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            Console.WriteLine(String.Join("\n", colors));
        }
        public static void ChangeBgColor(string commande)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            foreach (var color in colors)
            {
                if (Convert.ToString(color) == commande.Substring(8))
                {
                    Console.BackgroundColor = color;
                    Console.Clear();
                    return;
                }
            }
            Console.WriteLine("La couleur ou la syntaxe n'existe pas, taper 'color' pour voir la liste des couleurs disponible");
        }
    }
}

>>>>>>> 645b2a8f50e56037418da7091257b8671a442e3d
