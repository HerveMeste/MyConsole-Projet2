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

        public override void Execute()
        {
            IList<String> availablePaths = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());
            String fullPath = Path.GetFullPath(Arguments[0]);
            String desiredPath = fullPath;
            if (Arguments[0] != "..")
            {
                desiredPath = availablePaths.FirstOrDefault((path) => path == fullPath);
            }
            if (!String.IsNullOrWhiteSpace(desiredPath))
            {
                Directory.SetCurrentDirectory(desiredPath);
            }
        }
    }
}