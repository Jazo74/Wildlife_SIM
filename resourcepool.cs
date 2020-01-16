using System;
using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class ResourcePool
    {
        public List<Habitat> HabitatList = new List<Habitat>();
  

        public ResourcePool(String State)
        {           
            if (State == "new")
            {
                Habitat Rainforest = new Habitat("Rainforest");
                HabitatList.Add(Rainforest);
                Habitat TemperateForest = new Habitat("Temperate Forest");
                HabitatList.Add(TemperateForest);
                Habitat Sea = new Habitat("Sea");
                HabitatList.Add(Sea);
                Habitat Arctic = new Habitat("Arctic");
                HabitatList.Add(Arctic);
                Habitat Savannah = new Habitat("Savannah");
                HabitatList.Add(Savannah);
            }
        }
        
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

        public void GatherInformation()
        {

        }
        public void CreatingNewHabitat(String HabitatName)
        {
            Habitat NeuHabitat = new Habitat(HabitatName);
            HabitatList.Add(NeuHabitat);
        }
    }
}