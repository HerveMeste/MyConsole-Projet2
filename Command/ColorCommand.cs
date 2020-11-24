﻿using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public class ColorCommand : BaseCommand
    {
        public override String Name { get => "color"; }
        public override void Execute()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.WriteLine(String.Join("\n", colors));
        }
    }
}

