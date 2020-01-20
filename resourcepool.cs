using System;
using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class ResourcePool
    {
        // Properties

        public List<Habitat> HabitatList = new List<Habitat>();
        public List<HeatCollector> HeatCollectors = new List<HeatCollector>();
        public List<SolarPanel> SolarPanels = new List<SolarPanel>();
        public List<OxigenGenerator> OxigenGenerators = new List<OxigenGenerator>();
        public List<FoodReplicator> FoodReplicators = new List<FoodReplicator>();
        public List<WaterFilter> WaterFilters = new List<WaterFilter>();

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

        public decimal HeatLoad { get; set; }
        public decimal EnergyLoad { get; set; }
        public decimal OxigenLoad { get; set; }
        public decimal FoodLoad { get; set; }
        public decimal WaterLoad { get; set; }

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
                HeatCollectors.Add(new HeatCollector());
                SolarPanels.Add(new SolarPanel());
                FoodReplicators.Add(new FoodReplicator());
                OxigenGenerators.Add(new OxigenGenerator());
                WaterFilters.Add(new WaterFilter());
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
                SumAllCapacity();
            }
            while (AllEnergyReq > AllEnergyCapacity)
            {
                SolarPanels.Add(new SolarPanel());
                SumAllCapacity();
            }
            while (AllFoodReq > AllFoodCapacity)
            {
                FoodReplicators.Add(new FoodReplicator());
                SumAllCapacity();
            }
            while (AllOxigenReq > AllOxigenCapacity)
            {
                OxigenGenerators.Add(new OxigenGenerator());
                SumAllCapacity();
            }
            while (AllWaterReq > AllWaterCapacity)
            {
                WaterFilters.Add(new WaterFilter());
                SumAllCapacity();
            }
        }
        public void SetLoad()
        { 
            HeatLoad = Math.Round(AllHeatReq / (decimal)AllHeatCapacity * 100,0);
            EnergyLoad = Math.Round(AllEnergyReq / (decimal)AllEnergyCapacity * 100,0);
            FoodLoad = Math.Round(AllFoodReq / (decimal)AllFoodCapacity * 100,0);
            OxigenLoad = Math.Round(AllOxigenReq / (decimal)AllOxigenCapacity * 100,0);
            WaterLoad = Math.Round(AllWaterReq / (decimal)AllWaterCapacity * 100,0);    
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
        public void BirthDay()
        {
            foreach (Habitat x in HabitatList)
            {
                x.Birth();
            }
        }
        public void Dying()
        {
            foreach (Habitat x in HabitatList)
            {
                x.Dying();
            }
        }
        /*public void NaturalDeath()
        {
            foreach (Habitat x in HabitatList)
            {
                x.NaturalDeath();
            }
        }*/

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