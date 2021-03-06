﻿using System;
using System.Collections.Generic;
using System.Text;

namespace My_Console_Text
{
    public abstract class BaseCommand
    {
        public abstract String Command { get; }
        public IList<string> Arguments { get; set; }
        public abstract void Execute();
    }
}