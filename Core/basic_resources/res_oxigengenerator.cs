﻿using System;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class OxigenGenerator : ResourceGenerator
    {

        public OxigenGenerator()
        {
            //State = "Running";
            Capacity = 3500;
            Load = 0;
            //CriticalAccident = false;
            //Accident = false;
            //MaintenanceCounter = Capacity * 5;
        }

        /*public override void Maintenance()
        {
            MaintenanceCounter = Capacity * 2;
        }
        public override void AccidentHappens()
        {
            SomethingHappens = rnd.Next(1, 200);
            if (SomethingHappens == 200)
            {
                CriticalAccident = true;
            }
            else if (SomethingHappens > 190 & SomethingHappens < 200)
            {
                Accident = true;
                MaintenanceCounter += 5;
            }

        }*/
    }
}
