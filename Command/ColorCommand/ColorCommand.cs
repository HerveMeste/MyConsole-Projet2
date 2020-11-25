using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public class ColorCommand : BaseCommand
    {
        public override String Commands { get => "color"; }
        public override void Execute()
        {
            if (Arguments.Count == 0 )
            {
                ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
                Console.WriteLine(String.Join("\n", colors));
            }
            else
            {
                Console.WriteLine("erreur");
            }
        }
    }
}


