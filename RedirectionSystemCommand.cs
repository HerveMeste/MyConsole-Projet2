using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace My_Console_Text
{
    class RedirectionSystemCommand 
    {
        
        public static void RedirectionSystemMethod(FullCommand userEntry)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + userEntry.command+" "+userEntry.argument;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.Close();
        }

    }
}
