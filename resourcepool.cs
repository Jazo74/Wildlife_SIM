using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    List<HeatGenerator> HeatGenerators { get; set; }
    List<EnergyGenerator> EnergyGenerators { get; set; }
    List<OxigenGenerator> OxigenGenerators { get; set; }
    List<FoodGenerator> FoodGenerators { get; set; }
    List<WaterGenerator> WaterGenerators { get; set; }

    int HeatReserve { get; set; }
    int EnergyReserve { get; set; }
    int OxigenReserve { get; set; }
    int FoodReserve { get; set; }
    int WaterReserve { get; set; }
}