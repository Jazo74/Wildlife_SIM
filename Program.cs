﻿using System;
using System.Collections.Generic;
using codecool.miskolc.zoltan_jarmy.sanctuary.ui;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Program
    {
        public Lifecycle life;
        public ResourcePool arkOne;

        public Program()
        {
            arkOne = new ResourcePool("new");
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Program p = new Program();
            interactivity UI = new interactivity();
            UI.UI(p);
        }
    }
}
