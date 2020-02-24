using System;
using System.Collections.Generic;
using codecool.miskolc.zoltan_jarmy.sanctuary.ui;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Program
    {
        //public Monitor life;
        public ResourcePool arkOne;

        public Program()
        {
            arkOne = new ResourcePool("new");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            ConsoleSimulation cSim = new ConsoleSimulation();
            UI ui = new UI(cSim);
            ui.Start(p);
        }
    }
}
