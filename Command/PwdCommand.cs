using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace My_Console_Text
{
    public class PwdCommand : BaseCommand
    {
        public override String Command { get => "pwd"; }

        public override void Execute()
        {
            Console.WriteLine(Directory.GetCurrentDirectory() + "\n");
        }
    }
}
