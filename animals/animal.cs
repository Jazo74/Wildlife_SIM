using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Animal : Species
    {
        static int ID { get; set;}
        static Random rand = new Random();
        // Constructor
        public Animal(String SpeciesName, String Type, String IdealEnvironment)
        {
            ID += 1;
            OwnName = ID.ToString();
            ReqSpace = 1000;
            ReqHeatUnit = rand.Next(1, 5);
            ReqOxigenUnit = rand.Next(1, 5);
            ReqFoodUnit = rand.Next(1, 5);
            ReqWaterUnit = rand.Next(1, 5);
            ReqEnergyUnit = rand.Next(1, 5);
            //MaximumAge = rnd.Next(20000, 50000);
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
                //MaximumAge -= 100;
            }
        }
    }
}
