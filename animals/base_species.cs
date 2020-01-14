using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public abstract class Species
    {
        // Base Properties
        public Random rnd = new Random();
        public int SomethingHappens = 0;
        public String SpeciesName { get; set; } // Tiger, Eagle
        public String Type { get; set; } //carnivore, herbivore, omnivore
        public String IdealEnvironment { get; set; } // Tropical, Arctic
        //public String IdealFoodType { get; set; } // Meat, Grass, Grain, Vegetable, Fruit
        public int ReqSpace { get; set; }
        public int ReqHeatUnit { get; set; }
        public int ReqOxigenUnit { get; set; }
        public int ReqFoodUnit { get; set; }
        public int ReqWaterUnit { get; set; }
        public int ReqEnergyUnit { get; set; }
        public int MaximumAge { get; set; }
        public bool Dead { get; set; } = false;
        
        // Base Methods
        public abstract void Sickness();      
    }
}