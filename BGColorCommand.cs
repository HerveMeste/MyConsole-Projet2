using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    class BGColorCommand : BaseCommand
    {      
        public override String Name { get => "bgcolor"; }
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        ClearCommand clear = new ClearCommand();
        public override void Execute(FullCommand fullCommand)
        {
                foreach (var color in colors)
                {
                    if (Convert.ToString(color) == fullCommand.argument)
                    {
                        Console.BackgroundColor = color;
                        clear.Execute(fullCommand);
                        return;
                    }
                }
                Console.WriteLine(" Mauvaise couleur choisie");
        }
    }
}