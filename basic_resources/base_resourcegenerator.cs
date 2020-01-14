using System;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public abstract class ResourceGenerator
    {
        // Base Properties
        public Random rnd = new Random();
        public int SomethingHappens = 0;
        public int Capacity { get; set; }
        public int Load { get; set; }
        public int GeneratePerCycle { get; set; }
        public int MaintenanceCounter { get; set; }
        public bool CriticalAccident { get; set; }
        public bool Accident { get; set; }
        public String State { get; set; }
        // Base methods
        public abstract void AccidentHappens();
        public abstract void Maintenance();
        public abstract int Generate();

    }
}