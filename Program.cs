using System;
using System.Collections.Generic;
using codecool.miskolc.zoltan_jarmy.sanctuary.ui;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Program
    {
        public Simulation life;
        public ResourcePool arkOne;

        public Program()
        {
            arkOne = new ResourcePool("new");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            UI ui = new UI();
            ui.Start(p);
        }
    }
}
