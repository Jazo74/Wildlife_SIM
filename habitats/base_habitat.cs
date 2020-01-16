
using System;
using System.Collections.Generic;
using System.Timers;


namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Habitat
    {
        // Base Properties
        public String HabitatName { get; set; }
        public int Size { get; private set; }
        public int SumReqHeat { get; private set; }
        public int SumReqOxigen { get; private set; }
        public int SumReqWater { get; private set; }
        public int SumReqFood { get; private set; }
        public int SumReqEnergy { get; private set; }
        public List<Animal> AnimalList = new List<Animal>();
        //System.Timers.Timer(5000);
       
        //Constructor
        public Habitat(String HabitatName)
        {
            this.HabitatName = HabitatName;
            SumReqHeat = 0;
            SumReqOxigen = 0;
            SumReqWater = 0;
            SumReqFood = 0;
            SumReqEnergy = 0;
            Size = 0;
        }
        // Methods
        public void StartHabitat()
        {

        }
        public void HibernateHabitat()
        {

        }
        public void NewAnimal(String SpeciesName,String Type, String Environment)
        {
            Animal ThisAnimal = new Animal(SpeciesName, Type, Environment);
            AnimalList.Add(ThisAnimal);
        }
        public void GatherAllReq()
        {
            Size = 0;
            SumReqEnergy = 0;
            SumReqFood = 0;
            SumReqHeat = 0;
            SumReqOxigen = 0;
            SumReqWater = 0;
            foreach (Animal member in AnimalList)
            {
                Size += member.ReqSpace;
                SumReqHeat += member.ReqHeatUnit;
                SumReqOxigen += member.ReqOxigenUnit;
                SumReqFood += member.ReqFoodUnit;
                SumReqWater += member.ReqWaterUnit;
                SumReqEnergy += member.ReqEnergyUnit;
            }
        }
        public void RelocateAnimal(String OwnName)
        {
            for (int index = 0; index < AnimalList.Count; index ++)
            {
                if (AnimalList[index].OwnName == OwnName)
                {
                    AnimalList.RemoveAt(index);
                    // How to destroy this removed object?
                }
            }
        }
    }
}