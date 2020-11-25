using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace My_Console_Text
{
    public class RedirectionSystemCommand : BaseCommand
    {
        public override string Commands => Arguments[0];

        public override void Execute()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + Commands + " " + String.Join(" ", Arguments.Skip(1).ToList());
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.Close();
        }
    }
}
