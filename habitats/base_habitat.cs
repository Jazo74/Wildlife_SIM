﻿
using System;
using System.Collections.Generic;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Habitat
    {
        // Base Properties
        static Random rnd = new Random();
        public String HabitatName { get; set; }
        public int Size { get; private set; }
        public int SumReqHeat { get; private set; }
        public int SumReqOxigen { get; private set; }
        public int SumReqWater { get; private set; }
        public int SumReqFood { get; private set; }
        public int SumReqEnergy { get; private set; }
        public List<Animal> AnimalList = new List<Animal>();
        public Dictionary<string, int> AnimalDict = new Dictionary<string, int>();
        
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
            for (int index = 0; index < AnimalList.Count; index ++)
            {
                if (AnimalList[index].OwnName == OwnName)
                {
                    AnimalList.RemoveAt(index);
                    // How to destroy this removed object?
                }
            }
        }
        public void Birth()
        {
            if (rnd.Next(0,100) > 90)
            {
                int index = rnd.Next(0, AnimalList.Count);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A " + AnimalList[index].SpeciesName + " baby has born!");
                Console.ForegroundColor = ConsoleColor.White;
                AnimalList.Add(AnimalList[index]);
            }
        }
        public void Dying()
        {
            if (rnd.Next(0, 100) > 98)
            {
                int index = rnd.Next(0, AnimalList.Count);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A " + AnimalList[index].SpeciesName + " has died!");
                Console.ForegroundColor = ConsoleColor.White;
                AnimalList.RemoveAt(index);
            }
        }
        public void NaturalDeath()
        {
            for (int x = AnimalList.Count - 1; x >= 0; x--)
            {
                AnimalList[x].MaximumAge -= 1;
                if (AnimalList[x].MaximumAge < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A " + AnimalList[x].SpeciesName + " has died!");
                    Console.ForegroundColor = ConsoleColor.White;
                    AnimalList.RemoveAt(x);
                }
            }
        }
    }
}