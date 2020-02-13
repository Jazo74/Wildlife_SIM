using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public class DisplayMessage : IMessage
    {
        public void NegativeMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PositiveMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void NeutralMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
