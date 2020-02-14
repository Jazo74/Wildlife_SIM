using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class ResourcePool
    {
        private List<Habitat> habitatList = new List<Habitat>();
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

        public ResourcePool(String State) //constructor
        {
            if (State == "new")
            {
                habitatList.Add(new Habitat("Rainforest"));
                habitatList.Add(new Habitat("Temperate Forest"));
                habitatList.Add(new Habitat("Sea"));
                habitatList.Add(new Habitat("Arctic"));
                habitatList.Add(new Habitat("Savannah"));
                HeatCollectors.Add(new HeatCollector());
                SolarPanels.Add(new SolarPanel());
                FoodReplicators.Add(new FoodReplicator());
                OxigenGenerators.Add(new OxigenGenerator());
                WaterFilters.Add(new WaterFilter());
            }
        }
        public void ResourceCycle() // Resource math
        {
            SumAllRequiredResource();
            SumAllCapacity();
            CheckBalance();
            SetLoad();
        }
        private void SumAllRequiredResource() // gather all the required resources
        {
            AllHeatReq = 0;
            AllEnergyReq = 0;
            AllFoodReq = 0;
            AllOxigenReq = 0;
            AllWaterReq = 0;
            foreach (Habitat member in habitatList)
            {
                member.GatherAllReq();
                AllHeatReq += member.SumReqHeat;
                AllEnergyReq += member.SumReqEnergy;
                AllFoodReq += member.SumReqFood;
                AllOxigenReq += member.SumReqOxigen;
                AllWaterReq += member.SumReqWater;
            }
        }
        private void SumAllCapacity() // Sum all the current capacity of the facilities
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
        private void CheckBalance() //Checking the input/output balance
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
        private void SetLoad() // Set the neccessary loads
        {
            HeatLoad = Math.Round(AllHeatReq / (decimal)AllHeatCapacity * 100, 0);
            EnergyLoad = Math.Round(AllEnergyReq / (decimal)AllEnergyCapacity * 100, 0);
            FoodLoad = Math.Round(AllFoodReq / (decimal)AllFoodCapacity * 100, 0);
            OxigenLoad = Math.Round(AllOxigenReq / (decimal)AllOxigenCapacity * 100, 0);
            WaterLoad = Math.Round(AllWaterReq / (decimal)AllWaterCapacity * 100, 0);
        }
        public void CreatingAHabitat(String habitatName) // Creating a new habitat
        {
            Habitat NewHabitat = new Habitat(habitatName);
            habitatList.Add(NewHabitat);
        }
        public void RemovingAHabitat(string habitatName) // Removing a new habitat
        {
            if (!IsHabitatExist(habitatName)) { throw new HabitatNotExistException(); }
            for (int index = habitatList.Count-1; index >= 0; index--)
            {
                if (habitatList[index].HabitatName == habitatName)
                {
                    if (habitatList[index].AnimalList.Count > 0)
                    {
                        throw new NotEmptyHabitatException();
                    }
                    habitatList.RemoveAt(index);
                }
            }
        }
        public List<Habitat> GetHabitats() // Get the list of all habitats
        {
            return habitatList;
        }
        public bool IsHabitatExist(string habitatName) // Checking if the habitat exist
        {
            foreach (Habitat habitat in habitatList)
            {
                if (habitat.HabitatName == habitatName) {return true;}
            }
            return false;
        }
        public void AddNewAnimal(String SpeciesName, String Type, String Environment) // Adding new animals 
        {
            if (!IsHabitatExist(Environment))
            {
                throw new HabitatNotExistException();
            }
            foreach (Habitat habitat in habitatList)
            {
                if (habitat.HabitatName == Environment)
                {
                    habitat.AddNewAnimal(SpeciesName, Type, Environment);
                }
            }
        }
        public Animal FoundAnimal(String OwnName) // Checking if an animal exist in the system
        {
            foreach (Habitat habitat in habitatList)
            {
                foreach (Animal animal in habitat.AnimalList)
                {
                    if (animal.OwnName == OwnName)
                    {
                        return animal;
                    }
                }
            }
            throw new AnimalNotExistException();
        }
        public void RelocateAnimal(String OwnName) // Relocating (removing) an animal from the system
        {
            foreach (Habitat habitat in habitatList)
            {
                habitat.RelocateAnimal(OwnName);
            }
        }
        public void BirthDay() // Reproduction function
        {
            foreach (Habitat habitat in habitatList)
            {
                habitat.Birth();
            }
        }
        public void Dying() // 
        {
            foreach (Habitat habitat in habitatList)
            {
                habitat.Dying();
            }
        }
        
        public void SerializeMyList() // serializing the data to an xml file
        {
            XmlSerializer xmlBuild = new XmlSerializer(habitatList.GetType());
            FileStream file = new FileStream("sanctuary.xml", FileMode.Create);
            xmlBuild.Serialize(file, habitatList);
            file.Close();
        }
        public void DeSerializeMyList() // deserializing the the date from an xml file
        {
            if (!File.Exists("sanctuary.xml"))
            {
                throw new FileNotExistException();
            }
            XmlSerializer xmlBuild = new XmlSerializer(habitatList.GetType());
            FileStream file = new FileStream("sanctuary.xml", FileMode.Open);
            habitatList.Clear();
            List<Habitat> newObject = (List<Habitat>)xmlBuild.Deserialize(file);
            habitatList = newObject;
            file.Close();
        }
    }
}