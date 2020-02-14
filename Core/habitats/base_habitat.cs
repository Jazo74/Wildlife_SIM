
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static codecool.miskolc.zoltan_jarmy.sanctuary.ui.Toolbox;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    [Serializable]
    public class Habitat
    {
        // Base Properties
        static Random rnd = new Random();
        public String HabitatName { get; set; }
        [XmlIgnore]
        public int SumReqHeat { get; private set; }
        [XmlIgnore]
        public int SumReqOxigen { get; private set; }
        [XmlIgnore]
        public int SumReqWater { get; private set; }
        [XmlIgnore]
        public int SumReqFood { get; private set; }
        [XmlIgnore]
        public int SumReqEnergy { get; private set; }
        public List<Animal> AnimalList = new List<Animal>();
        [XmlIgnore]
        public Dictionary<string, int> AnimalDict = new Dictionary<string, int>();
        
        //Constructor
        public Habitat() { }
        public Habitat(String HabitatName)
        {
            this.HabitatName = HabitatName;
            SumReqHeat = 0;
            SumReqOxigen = 0;
            SumReqWater = 0;
            SumReqFood = 0;
            SumReqEnergy = 0;
        }

        public void GatherAllReq()
        {
            SumReqEnergy = 0;
            SumReqFood = 0;
            SumReqHeat = 0;
            SumReqOxigen = 0;
            SumReqWater = 0;
            foreach (Animal member in AnimalList)
            {
                SumReqHeat += member.ReqHeatUnit;
                SumReqOxigen += member.ReqOxigenUnit;
                SumReqFood += member.ReqFoodUnit;
                SumReqWater += member.ReqWaterUnit;
                SumReqEnergy += member.ReqEnergyUnit;
            }
        }
        public void SetHabitatName(string habitatName)
        {
            this.HabitatName = habitatName;
        }
        public void SumAnimals()
        {
            AnimalDict.Clear();
            foreach (Animal member in AnimalList)
            {
                if (AnimalDict.ContainsKey(member.SpeciesName) == false)
                {
                    AnimalDict.Add(member.SpeciesName, 1);
                }
                else
                {
                    AnimalDict[member.SpeciesName] += 1; 
                }
            }
        }
        public void AddNewAnimal(String SpeciesName, String Type, String Environment)
        {
            AnimalList.Add(new Animal(SpeciesName, Type, Environment));
        }
        public void RelocateAnimal(String OwnName)
        {
            bool found = false;
            for (int index = AnimalList.Count-1; index >= 0 ; index --)
            {
                if (AnimalList[index].OwnName == OwnName)
                {
                    AnimalList.RemoveAt(index);
                    found = true;
                }
            }
            if (found == false) { throw new AnimalNotExistException(); }
        }
        public void Birth()
        {
            if (rnd.Next(0,100) > 90)
            {
                if (AnimalList.Count > 0)
                {
                    int index = rnd.Next(0, AnimalList.Count);
                    WriteLineGreen("A " + AnimalList[index].SpeciesName + " baby has born!");
                    AddNewAnimal(AnimalList[index].SpeciesName, AnimalList[index].Type, AnimalList[index].IdealEnvironment);
                }
            }
        }
        public void Dying()
        {
            if (rnd.Next(0, 100) > 98)
            {
                if (AnimalList.Count > 50)
                {
                    int index = rnd.Next(0, AnimalList.Count);
                    WriteLineRed("A " + AnimalList[index].SpeciesName + " has died!");
                    AnimalList.RemoveAt(index);
                }
            }
        }
    }
}