using System;
using System.IO;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public class FIleMessage : IMessage
    {
        StreamWriter streamWriter = new StreamWriter("message_logger.txt",true);

        public void NegativeMessage(string message)
        {
            streamWriter.WriteLine("Negative - " + message);
            streamWriter.Close();
        }
        public void PositiveMessage(string message)
        {
            streamWriter.WriteLine("Positive - " + message);
            streamWriter.Close();
        }
        public void NeutralMessage(string message)
        {
            streamWriter.WriteLine("Neutral - " + message);
            streamWriter.Close();
        }
    }
}
