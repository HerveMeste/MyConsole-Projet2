using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
  class ExitCommand : BaseCommand
    {
        public override string Name => "exit";
        public override void Execute(FullCommand fullCommand) 
        {
            Environment.Exit(0);
        }
    }
}