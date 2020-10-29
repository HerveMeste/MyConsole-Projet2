using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace My_Console_Text
{
    public class ChangeDirectoryCommand : BaseCommand
    {
        public override String Name { get => "cd"; }

        public override void Execute(String[] fullCommand)
        {
            if (fullCommand[1] == "..")
            {
                String parent = Directory.GetParent(".").FullName;
                Directory.SetCurrentDirectory(parent);
            }
            else
            {
                Directory.SetCurrentDirectory(fullCommand[1]);
            }
        }
    }
}
