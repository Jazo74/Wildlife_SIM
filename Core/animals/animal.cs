using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    [Serializable]
    public class Animal : Species
    {
        static int ID { get; set;}
        static Random rand = new Random();
        // Constructor
        public Animal() { }
        public Animal(String SpeciesName, String Type, String IdealEnvironment)
        {
            ID += 1;
            OwnName = ID.ToString();
            ReqHeatUnit = rand.Next(1, 5);
            ReqOxigenUnit = rand.Next(1, 5);
            ReqFoodUnit = rand.Next(1, 5);
            ReqWaterUnit = rand.Next(1, 5);
            ReqEnergyUnit = rand.Next(1, 5);
            this.SpeciesName = SpeciesName;
            this.Type = Type;
            this.IdealEnvironment = IdealEnvironment;
        }
        // Methods
    }
}
