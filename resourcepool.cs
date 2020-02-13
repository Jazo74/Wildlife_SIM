using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

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
        private void SumAllRequiredResource()
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
        private void SumAllCapacity()
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
        private void CheckBalance()
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
        private void SetLoad()
        {
            HeatLoad = Math.Round(AllHeatReq / (decimal)AllHeatCapacity * 100, 0);
            EnergyLoad = Math.Round(AllEnergyReq / (decimal)AllEnergyCapacity * 100, 0);
            FoodLoad = Math.Round(AllFoodReq / (decimal)AllFoodCapacity * 100, 0);
            OxigenLoad = Math.Round(AllOxigenReq / (decimal)AllOxigenCapacity * 100, 0);
            WaterLoad = Math.Round(AllWaterReq / (decimal)AllWaterCapacity * 100, 0);
        }
        public void CreatingAHabitat(String habitatName)
        {
            Habitat NewHabitat = new Habitat(habitatName);
            HabitatList.Add(NewHabitat);
        }
        public void AddNewAnimal(String SpeciesName, String Type, String Environment)
        {
            if (!IsHabitatExist(Environment))
            {
                throw new HabitatNotExistException();
            }
            foreach (Habitat member in HabitatList)
            {
                if (member.HabitatName == Environment)
                {
                    member.AddNewAnimal(SpeciesName, Type, Environment);
                }
            }
        }
        public bool RelocateAnimal(String OwnName)
        {
            foreach (Habitat member in HabitatList)
            {
                foreach (Animal animal in member.AnimalList)
                {
                    if (animal.OwnName == OwnName)
                    {
                        member.RelocateAnimal(OwnName);
                        return true;
                    }
                }
            }
            return false;
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
        private bool IsHabitatExist(string habitatName)
        {
            foreach (Habitat habitat in HabitatList)
            {
                if (habitat.HabitatName == habitatName)
                {
                    return true;
                }
            }
            return false;
        }
        public void SerializeMyList() // serializing the data to an xml file
        {
            XmlSerializer xmlBuild = new XmlSerializer(HabitatList.GetType());
            FileStream file = new FileStream("sanctuary.xml", FileMode.Create);
            xmlBuild.Serialize(file, HabitatList);
            file.Close();
        }
        public void DeSerializeMyList() // deserializing the the date from an xml file
        {
            if (!File.Exists("sanctuary.xml"))
            {
                throw new FileNotExistException();
            }
            XmlSerializer xmlBuild = new XmlSerializer(HabitatList.GetType());
            FileStream file = new FileStream("sanctuary.xml", FileMode.Open);
            HabitatList.Clear();
            List<Habitat> newObject = (List<Habitat>)xmlBuild.Deserialize(file);
            HabitatList = newObject;
            file.Close();
        }
    }
}