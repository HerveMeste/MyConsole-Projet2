using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace My_Console_Text
{
    public class PwdCommand : BaseCommand
    {
        public override String Name { get => "pwd"; }

        public override void Execute(FullCommand fullCommand)
        {
            Console.WriteLine(Directory.GetCurrentDirectory()+"\n");
        }
    }
}
