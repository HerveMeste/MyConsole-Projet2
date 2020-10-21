﻿using Microsoft.VisualBasic;
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
        private String _currentDirectory = "C:\\Users";
        public string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void Run()
        {
            while (true)
            {
                String command = Prompt();
               
                if (command.Substring(0,3) == "cd ")
                {
                    ChangeDirectoryCd(_currentDirectory, command);
                }
                else if (command == "dir")
                {
                    ListDirectory(_currentDirectory);/* fournir l'argument de dir, si il n'y en a pas, c'est _currentDirectory */
                }
                else
                {
                    Console.WriteLine("mauvaise commande");
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
            string chem = _currentDirectory + "\\" + command.Substring(3);
            string[] tabfichier = Directory.GetFileSystemEntries(_currentDirectory);
            for (int i = 0; i < tabfichier.Length; i++)
            {
                if (tabfichier[i] == chem)
                {

                    newPath = _currentDirectory + "\\" + command.Substring(3);
                    _currentDirectory = newPath;
                    return;
                    
                }               
            }
            Console.WriteLine("repertoire inexistant");
            
        }

        public void ListDirectory(String directoryPath)
        {
            IEnumerable<String> listedFiles = Directory.EnumerateFiles(directoryPath);
            IEnumerable<String> listedDirectories = Directory.EnumerateDirectories(directoryPath);
            Console.WriteLine("{0}\n{1}", String.Join("\n", listedFiles), String.Join("\n", listedDirectories));
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