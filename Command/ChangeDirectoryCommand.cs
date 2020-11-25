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
        public override String Commands { get => "cd"; }

        public override void Execute()
        {           
            try
            {
                Directory.SetCurrentDirectory(String.Join(" ", Arguments));
            }
            catch
            {
                Directory.GetCurrentDirectory();
            }           
        }
    }
}