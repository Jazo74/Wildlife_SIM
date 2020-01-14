using System;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    class HeatCollector : ResourceGenerator
    {

        public HeatCollector()
        {
            State = "Running";
            Capacity = 100;
            Load = 0;
            GeneratePerCycle = 1;
            CriticalAccident = false;
            Accident = false;
            MaintenanceCounter = Capacity * 5;
        }

        public override int Generate()
        {
            return GeneratePerCycle * Load;
        }

        public override void Maintenance()
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
            
        }
    }
}
