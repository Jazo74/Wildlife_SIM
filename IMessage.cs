using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public interface IMessage
    {
        public void NegativeMessage(string message);
        public void PositiveMessage(string message);
        public void NeutralMessage(string message);
    }
}
