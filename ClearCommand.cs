using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public class ClearCommand : BaseCommand
    {
        public override String Name { get => "cls"; }

        public override void Execute(String[] fullCommand)
        {
            Console.Clear();
        }
    }
}
