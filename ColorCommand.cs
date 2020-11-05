using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public class ColorCommand : BaseCommand
    {
        public override String Name { get => "color"; }
        public override void Execute(String[] fullCommand)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ClearCommand clear = new ClearCommand();
            if (fullCommand.Length == 1)
            {
                Console.WriteLine(String.Join("\n", colors));
            }
            else if (fullCommand.Length == 3 && fullCommand[1] == "fg")
            {
                foreach (var color in colors)
                {
                    if (Convert.ToString(color) == fullCommand[2])
                    {
                        Console.ForegroundColor = color;
                        return;
                    }
                }
            }
            else if (fullCommand.Length == 3 && fullCommand[1] == "bg")
            {
                foreach (var color in colors)
                {
                    if (Convert.ToString(color) == fullCommand[2])
                    {
                        Console.BackgroundColor = color;
                        clear.Execute(fullCommand);
                        return;
                    }
                }
            }
            Console.WriteLine("La couleur ou la syntaxe n'existe pas, taper 'color' pour voir la liste des couleurs disponible");
        }
    }
}