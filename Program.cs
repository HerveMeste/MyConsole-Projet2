using System;
using System.Collections.Generic;
using System.IO;

namespace My_Console_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringCommand = new List<string>();
            while(true)
                
            {
                Console.Write("C:\\");
                stringCommand.Add(Console.ReadLine());
                foreach(string command in stringCommand)
                {
                    Console.Write(command + "\\");
                    
                }
                stringCommand.Reverse();
            }
        }
    }
/*    public abstract class MyConsole
    {

    }
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
