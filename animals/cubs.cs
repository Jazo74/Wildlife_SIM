using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Cub : Animal
    {
        // Properties
        int Growing { get; set; }

        // Constructor
        public Cub(String SpeciesName, String Type, String IdealEnvironment) : base(SpeciesName, Type, IdealEnvironment)
        {
            ReqSpace = 300;
            ReqHeatUnit = 1;
            ReqOxigenUnit = 1;
            ReqFoodUnit = 1;
            ReqWaterUnit = 1;
            ReqEnergyUnit = 1;
            this.Growing = 300;
        }
    }
}
