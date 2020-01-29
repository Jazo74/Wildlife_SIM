using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public abstract class Species
    {
        public String OwnName { get; set; }
        //public Random rnd = new Random();
        public String SpeciesName { get; set; } // Tiger, Eagle
        public String Type { get; set; } //carnivore, herbivore, omnivore
        public String IdealEnvironment { get; set; } // Tropical, Arctic
        public int ReqHeatUnit { get; set; }
        public int ReqOxigenUnit { get; set; }
        public int ReqFoodUnit { get; set; }
        public int ReqWaterUnit { get; set; }
        public int ReqEnergyUnit { get; set; }
        
        // Base Methods
    }
}