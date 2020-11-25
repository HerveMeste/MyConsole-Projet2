using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
  class ExitCommand : BaseCommand
    {
        public override string Commands => "exit";
        public override void Execute() 
        {
            Environment.Exit(0);
        }
    }
}