using System;
using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class ResourcePool
    {
        // Properties

        public List<Habitat> HabitatList = new List<Habitat>();
        //public List<ResourceGenerator> ResourceList = new List<ResourceGenerator>();
        
        List<HeatCollector> HeatCollectors { get; set; }
        List<SolarPanel> SolarPanels { get; set; }
        List<OxigenGenerator> OxigenGenerators { get; set; }
        List<FoodReplicator> FoodReplicators { get; set; }
        List<WaterFilter> WaterFilters { get; set; }

        int AllHeatReq { get; set; }
        int AllEnergyReq { get; set; }
        int AllOxigenReq { get; set; }
        int AllFoodReq { get; set; }
        int AllWaterReq { get; set; }

        int AllHeatCapacity { get; set; }
        int AllEnergyCapacity { get; set; }
        int AllOxigenCapacity { get; set; }
        int AllFoodCapacity { get; set; }
        int AllWaterCapacity { get; set; }

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
        // Methods
        public void ResourceCycle()
        {
            SumAllRequiredResource();
            SumAllCapacity();
            CheckBalance();
            SetLoad();
        }
        public void SumAllRequiredResource()
        {
            AllHeatReq = 0;
            AllEnergyReq = 0;
            AllFoodReq = 0;
            AllOxigenReq = 0;
            AllWaterReq = 0;
            foreach (Habitat member in HabitatList)
            {
                member.GatherAllReq();
                AllHeatReq += member.SumReqHeat;
                AllEnergyReq += member.SumReqEnergy;
                AllFoodReq += member.SumReqFood;
                AllOxigenReq += member.SumReqOxigen;
                AllWaterReq += member.SumReqWater;
            }
        }
        public void SumAllCapacity()
        {
            AllHeatCapacity = 0;
            AllEnergyCapacity = 0;
            AllFoodCapacity = 0;
            AllOxigenCapacity = 0;
            AllWaterCapacity = 0;
            foreach (HeatCollector member in HeatCollectors)
            {
                AllHeatCapacity += member.Capacity;
            }
            foreach (SolarPanel member in SolarPanels)
            {
                AllEnergyCapacity += member.Capacity;
            }
            foreach (FoodReplicator member in FoodReplicators)
            {
                AllFoodCapacity += member.Capacity;
            }
            foreach (OxigenGenerator member in OxigenGenerators)
            {
                AllOxigenCapacity += member.Capacity;
            }
            foreach (WaterFilter member in WaterFilters)
            {
                AllWaterCapacity += member.Capacity;
            }

        }
        public void CheckBalance()
        {
            while (AllHeatReq > AllHeatCapacity)
            {
                HeatCollectors.Add(new HeatCollector());
            }
            while (AllEnergyReq > AllEnergyCapacity)
            {
                SolarPanels.Add(new SolarPanel());
            }
            while (AllFoodReq > AllFoodCapacity)
            {
                FoodReplicators.Add(new FoodReplicator());
            }
            while (AllOxigenReq > AllOxigenCapacity)
            {
                OxigenGenerators.Add(new OxigenGenerator());
            }
            while (AllWaterReq > AllWaterCapacity)
            {
                WaterFilters.Add(new WaterFilter());
            }
        }
        public void SetLoad()
        { 
            foreach (HeatCollector member in HeatCollectors)
            {
                member.Load = AllHeatReq / AllHeatCapacity * (float)100;
            }
            foreach (SolarPanel member in SolarPanels)
            {
                member.Load = AllEnergyReq / AllEnergyCapacity * (float)100;
            }
            foreach (FoodReplicator member in FoodReplicators)
            {
                member.Load = AllFoodReq / AllFoodCapacity * (float)100;
            }
            foreach (OxigenGenerator member in OxigenGenerators)
            {
                member.Load = AllOxigenReq / AllOxigenCapacity * (float)100;
            }
            foreach (WaterFilter member in WaterFilters)
            {
                member.Load = AllWaterReq / AllWaterCapacity * (float)100;
            }
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