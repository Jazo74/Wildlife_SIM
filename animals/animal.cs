using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Animal : Species
    {
        static int ID { get; set;} 
        // Constructor
        public Animal(String SpeciesName, String Type, String IdealEnvironment)
        {
            ID += 1;
            OwnName = ID.ToString();
            ReqSpace = 1000;
            ReqHeatUnit = 1;
            ReqOxigenUnit = 3;
            ReqFoodUnit = 2;
            ReqWaterUnit = 2;
            ReqEnergyUnit = 1;
            MaximumAge = rnd.Next(5000,7000);
            this.SpeciesName = SpeciesName;
            this.Type = Type;
            this.IdealEnvironment = IdealEnvironment;
        }
        // Methods
        public override void Sickness()
        {
            SomethingHappens = rnd.Next(1,200);
            if (SomethingHappens == 200)
            {
                Dead = true;
            }
            else if (SomethingHappens > 190 & SomethingHappens < 200)
            {
                MaximumAge -= 100;
            }
        }
    }
}
