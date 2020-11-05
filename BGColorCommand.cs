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
        public override void Execute(String[] fullCommand)
        {
            if (fullCommand.Length == 2)
            {
                foreach (var color in colors)
                {
                    if (Convert.ToString(color) == fullCommand[1])
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
}
