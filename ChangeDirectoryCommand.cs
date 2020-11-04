using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace My_Console_Text
{
    public class ChangeDirectoryCommand : BaseCommand
    {
        public override String Name { get => "cd"; }

        public override void Execute(String[] fullCommand)
        {
            if (fullCommand.Length == 1)
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
            }
            else
            {
                try
                {
                    Directory.SetCurrentDirectory(fullCommand[1]);
                }
                catch
                {
                    string[] arrayPath = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());
                    fullCommand[1] = Directory.GetCurrentDirectory() + "\\" + fullCommand[1];
                    for (int i = 0; i < arrayPath.Length; i++)
                    {
                        if (arrayPath[i] == fullCommand[1])
                        {
                            Directory.SetCurrentDirectory(fullCommand[1]);
                            return;
                        }
                    }
                    Console.WriteLine("Wrong command");
                }
            }
        }
    }
}