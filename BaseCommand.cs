using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public abstract class BaseCommand
    {
        public abstract String Name { get; }
        public abstract void Execute(String[] fullCommand);
    }
}
