using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace My_Console_Text
{
    class RedirectionSystemCommand 
    {
        
        public static void RedirectionSystemMethod(string[] userEntry)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            if (userEntry.Length >= 2)
            {
                for (int i = 1; i < userEntry.Length; i++)
                {
                    userEntry[0] = userEntry[0] + " " + userEntry[i];
                }
            }
            process.StartInfo.Arguments = "/C " + userEntry[0]; //+" "+ userEntry[1]; // Commande à exécuter
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.Close();
        }

    }
}
