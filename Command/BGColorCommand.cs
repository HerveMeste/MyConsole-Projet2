using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace My_Console_Text
{
    class BGColorCommand : BaseCommand
    {      
        public override String Name { get => "bgcolor"; }
        
        public override void Execute()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ClearCommand clear = new ClearCommand();
            Console.BackgroundColor = colors.First((color) => Convert.ToString(color) == Arguments[0]);
        }
    }
}