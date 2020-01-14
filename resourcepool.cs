using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    class ResourcePool
    {
        List<HeatCollector> HeatGenerators { get; set; }
        List<SolarPanel> EnergyGenerators { get; set; }
        List<OxigenGenerator> OxigenGenerators { get; set; }
        List<FoodReplicator> FoodGenerators { get; set; }
        List<WaterFilter> WaterGenerators { get; set; }

        List<Habitat> 

        int HeatReserve { get; set; }
        int EnergyReserve { get; set; }
        int OxigenReserve { get; set; }
        int FoodReserve { get; set; }
        int WaterReserve { get; set; }

        int HeatCapacity { get; set; }
        int EnergyCapacity { get; set; }
        int OxigenCapacity { get; set; }
        int FoodCapacity { get; set; }
        int WaterCapacity { get; set; }

        int HeatLoad { get; set; }
        int EnergyLoad { get; set; }
        int OxigenLoad { get; set; }
        int FoodLoad { get; set; }
        int WaterLoad { get; set; }

        public void GatherInformation()
        {

        }
    }
}