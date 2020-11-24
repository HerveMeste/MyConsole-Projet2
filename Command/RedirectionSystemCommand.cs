using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace My_Console_Text
{
    public class RedirectionSystemCommand : BaseCommand
    {
        public override string Name => Arguments[0];

        public override void Execute()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + Name + " " + String.Join(' ', Arguments);
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.Close();
        }
    }
}
