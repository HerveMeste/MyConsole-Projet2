using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace My_Console_Text
{
    public class ChangeDirectoryCommand : BaseCommand
    {
        public override String Name { get => "cd"; }
        public override void Execute(FullCommand fullCommand)
        {
            try
            {
                Directory.SetCurrentDirectory(fullCommand.argument);
            }
            catch
            {
                string[] arrayPath = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());
                string Path = Directory.GetCurrentDirectory() + "\\" + fullCommand.argument;
                for (int i = 0; i < arrayPath.Length; i++)
                {
                    if (arrayPath[i] == Path)
                    {
                        Directory.SetCurrentDirectory(fullCommand.argument);
                        return;
                    }
                }
                Console.WriteLine("Wrong command");
            }
        }
    }
}