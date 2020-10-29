namespace My_Console_Text
{
    public class ListDirectoryCommand : BaseCommand
    {
        public override string Name => "dir";

        public override void Execute(string[] fullCommand)
        {
            System.Console.WriteLine("Bonne chance :)");
        }
    }
}