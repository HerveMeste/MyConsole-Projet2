using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace My_Console_Text
{
    public class ChangeDirectoryCommand : BaseCommand
    {
        public override String Name { get => "cd"; }

        public override void Execute(String[] fullCommand)
        {
            if (fullCommand.Length == 1)
            {
                // afficher seulement l'adresse d'ou on se trouve 
            }
            else if (fullCommand.Length == 2 && fullCommand[1] == "..")
            {
                String parent = Directory.GetParent(".").FullName;
                Directory.SetCurrentDirectory(parent);

            }
            else if (fullCommand.Length == 2) // regler le probleme d'une mauvaise saisie.
            {
                Directory.SetCurrentDirectory(fullCommand[1]);
            }
            else
            {
                Console.WriteLine("Mauvaise commande");
            }
        }
    }
}