using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    class FGColorCommand : BaseCommand
    {
        public override String Name { get => "fgcolor"; }
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        public override void Execute(FullCommand fullCommand)
        {           
            foreach (var color in colors)
            {
                if (Convert.ToString(color) == fullCommand.argument)
                {
                    Console.ForegroundColor = color;
                    return;
                }
            }
            Console.WriteLine(" Mauvaise couleur choisie");
        } 
    }
}