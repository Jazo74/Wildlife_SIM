using System;
using System.Collections.Generic;
using System.Threading;
using static codecool.miskolc.zoltan_jarmy.sanctuary.ui.Toolbox;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Simulation
    {
        public Simulation()
        {
        }
        public void LifeCycle(Program p)
        {
            StarterPopulation(p);
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                p.arkOne.ResourceCycle();
                ShowAnimals(p);
                ShowRequiredResources(p);
                ShowResourceGenerators(p);
                p.arkOne.BirthDay();
                p.arkOne.Dying();
                Thread.Sleep(300);
            }
        }
        void ShowAnimals(Program p)
        {
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Current Population:");

            foreach (Habitat habs in p.arkOne.GetHabitats())
            {
                habs.SumAnimals();
                Console.Write(habs.HabitatName.PadRight(18));
                foreach (KeyValuePair<string, int> x in habs.AnimalDict)
                {
                    string tempString = x.Key.PadRight(11) + " " + x.Value;
                    Console.Write(tempString.PadRight(17));
                }
                Console.WriteLine();
            }
        }
        void ShowRequiredResources(Program p)
        {
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Required Resources:");
            WriteLineBlue("Zone               Energy(kW)   Heat(kJ)   Food(unit)   Water(m3)   Oxigen(m3)");
            foreach (Habitat member in p.arkOne.GetHabitats())
            {
                Console.Write(member.HabitatName.ToString().PadRight(19));
                Console.Write(member.SumReqEnergy.ToString().PadRight(13));
                Console.Write(member.SumReqHeat.ToString().PadRight(11));
                Console.Write(member.SumReqFood.ToString().PadRight(13));
                Console.Write(member.SumReqWater.ToString().PadRight(12));
                Console.WriteLine(member.SumReqOxigen.ToString().PadRight(12));
            }
        }
        void ShowResourceGenerators(Program p)
        {
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Running Facilities:");
            Console.WriteLine("Heatcollectors".PadRight(19) + p.arkOne.HeatCollectors.Count + " block, Load: " + p.arkOne.HeatLoad + " %");
            Console.WriteLine("Solarpanels".PadRight(19) + p.arkOne.SolarPanels.Count + " block, Load: " + p.arkOne.EnergyLoad + " %");
            Console.WriteLine("Foodreplicators".PadRight(19) + p.arkOne.FoodReplicators.Count + " block, Load: " + p.arkOne.FoodLoad + " %");
            Console.WriteLine("Oxigen generators".PadRight(19) + p.arkOne.OxigenGenerators.Count + " block, Load: " + p.arkOne.OxigenLoad + " %");
            Console.WriteLine("Water filters: ".PadRight(19) + p.arkOne.WaterFilters.Count + " block, Load: " + p.arkOne.WaterLoad + " %");
            WriteLineBlue("-------------------------------------------------------------------------------");
            WriteLineBlue("Messages:");

        }
        void StarterPopulation(Program p)
        {
            int counter = 0;
            while (counter < 10)
            {
                try
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
                    counter++;
                }
                catch (HabitatNotExistException)
                {
                    WriteLineRed("Habitat is not exist!");
                    Thread.Sleep(200);
                }
            }
        }
        
    }
}
