using System;
using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class ResourcePool
    {
        // Properties
        public List<Habitat> HabitatList = new List<Habitat>();
        List<HeatCollector> HeatGenerators { get; set; }
        List<SolarPanel> EnergyGenerators { get; set; }
        List<OxigenGenerator> OxigenGenerators { get; set; }
        List<FoodReplicator> FoodGenerators { get; set; }
        List<WaterFilter> WaterGenerators { get; set; }
        int HeatReserve { get; set; }
        int EnergyReserve { get; set; }
        int OxigenReserve { get; set; }
        int FoodReserve { get; set; }
        int WaterReserve { get; set; }

        int SumHeatCapacity { get; set; }
        int SumEnergyCapacity { get; set; }
        int SumOxigenCapacity { get; set; }
        int SumFoodCapacity { get; set; }
        int SumWaterCapacity { get; set; }

        int SumHeatLoad { get; set; }
        int SumEnergyLoad { get; set; }
        int SumOxigenLoad { get; set; }
        int SumFoodLoad { get; set; }
        int SumWaterLoad { get; set; }

        // Constructor
        public ResourcePool(String State)
        {           
            if (State == "new")
            {
                HabitatList.Add(new Habitat("Rainforest"));
                HabitatList.Add(new Habitat("Temperate Forest"));
                HabitatList.Add(new Habitat("Sea"));
                HabitatList.Add(new Habitat("Arctic"));
                HabitatList.Add(new Habitat("Savannah"));
            }
        }

        public void GatherInformation()
        {

        }
        public void CreatingAHabitat(String habitatName)
        {
            Habitat NewHabitat  = new Habitat(habitatName);
            HabitatList.Add(NewHabitat);
        }

        public void AddNewAnimal(String SpeciesName, String Type, String Environment)
        {
            foreach (Habitat member in HabitatList)
            {
                if (member.HabitatName == Environment)
                {
                    member.AddNewAnimal(SpeciesName, Type, Environment);
                }
            }
        }

        public void RelocateAnimal(String OwnName, String Environment)
        {
            foreach (Habitat member in HabitatList)
            {
                if (member.HabitatName == Environment)
                {
                    member.RelocateAnimal(OwnName);
                }
            }
        }

        /*public Habitat FindHabitatByName(string habitatName)
       {
           foreach (Habitat habitat in HabitatList)
           {
               if (habitat.HabitatName == habitatName)
               {
                   return habitat;
               }
           }
           return null;
       }*/
    }
}