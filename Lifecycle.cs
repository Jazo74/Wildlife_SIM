using System;
using System.Collections.Generic;
using System.Threading;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Lifecycle
    {
        public Lifecycle()
        {
        }
        void ShowAnimals(Program p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                             The current population:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Habitat habs in p.arkOne.HabitatList)
            {
                habs.SumAnimals();
                Console.Write(habs.HabitatName.PadRight(18));
                foreach (KeyValuePair<string, int> x in habs.AnimalDict)
                {
                    string tempString = x.Key.PadRight(11) + " " + x.Value;
                    Console.Write(tempString.PadRight(17));
                    //Console.Write(x.Key + "(");
                    //Console.Write(x.Value + ") ");
                }
                Console.WriteLine();
            }
        }
        void TestSumReqRes(Program p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                                 Required Resources");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Zone               Energy   Heat   Food   Water   Oxigen");
            foreach (Habitat member in p.arkOne.HabitatList)
            {
                Console.Write(member.HabitatName.ToString().PadRight(19));
                Console.Write(member.SumReqEnergy.ToString().PadRight(9));
                Console.Write(member.SumReqHeat.ToString().PadRight(7));
                Console.Write(member.SumReqFood.ToString().PadRight(7));
                Console.Write(member.SumReqWater.ToString().PadRight(8));
                Console.WriteLine(member.SumReqOxigen.ToString().PadRight(8));
            }
        }
        void TestResGenerators(Program p)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                                Running facilities");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Heatcollectors".PadRight(19) + p.arkOne.HeatCollectors.Count + " block, Load: " + p.arkOne.HeatLoad + " %");
            Console.WriteLine("Solarpanels".PadRight(19) + p.arkOne.SolarPanels.Count + " block, Load: " + p.arkOne.EnergyLoad + " %");
            Console.WriteLine("Foodreplicators".PadRight(19) + p.arkOne.FoodReplicators.Count + " block, Load: " + p.arkOne.FoodLoad + " %");
            Console.WriteLine("Oxigen generators".PadRight(19) + p.arkOne.OxigenGenerators.Count + " block, Load: " + p.arkOne.OxigenLoad + " %");
            Console.WriteLine("Water filters: ".PadRight(19) + p.arkOne.WaterFilters.Count + " block, Load: " + p.arkOne.WaterLoad + " %");

        }
        void StartPopulate(Program p)
        {
            for (int i = 0; i < 10; i++)
            {
                p.arkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                p.arkOne.AddNewAnimal("Panda", "Herbivore", "Rainforest");
                p.arkOne.AddNewAnimal("Chimp", "Omnivore", "Rainforest");
                p.arkOne.AddNewAnimal("Zebra", "Herbivore", "Savannah");
                p.arkOne.AddNewAnimal("Lion", "Carnivore", "Savannah");
                p.arkOne.AddNewAnimal("Antilop", "Herbivore", "Savannah");
                p.arkOne.AddNewAnimal("Wolf", "Carnivore", "Temperate Forest");
                p.arkOne.AddNewAnimal("Beaver", "Herbivore", "Temperate Forest");
                p.arkOne.AddNewAnimal("Bald Eagle", "Carnivore", "Temperate Forest");
                p.arkOne.AddNewAnimal("Polar bear", "Carnivore", "Arctic");
                p.arkOne.AddNewAnimal("Seal", "Carnivore", "Arctic");
                p.arkOne.AddNewAnimal("Penguin", "Carnivore", "Arctic");
                p.arkOne.AddNewAnimal("Dolphin", "Carnivore", "Sea");
                p.arkOne.AddNewAnimal("Turtle", "Herbivore", "Sea");
                p.arkOne.AddNewAnimal("Seagull", "Herbivore", "Sea");
            }
        }
        public void Cycle(Program p)
        {
            StartPopulate(p);
            while (!Console.KeyAvailable)
            {
                p.arkOne.ResourceCycle();
                ShowAnimals(p);
                TestSumReqRes(p);
                TestResGenerators(p);
                Console.WriteLine();
                p.arkOne.BirthDay();
                p.arkOne.Dying();
                //arkOne.NaturalDeath();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
