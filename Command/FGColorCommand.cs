using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace My_Console_Text
{
    class FGColorCommand : BaseCommand
    {
        public override String Name { get => "fgcolor"; }
        public override void Execute()
        {      
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.ForegroundColor= colors.First((color) => Convert.ToString(color) == Arguments[0]);
        } 
    }
}