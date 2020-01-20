using System;
using System.Collections.Generic;
using System.Threading;
using codecool.miskolc.zoltan_jarmy.sanctuary.ui;


namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    class Program
    {
        // Fields
            ResourcePool arkOne = new ResourcePool("new");
            static Program sanctuary = new Program();
        // Methods
        static void Main(string[] args)
        {
            Console.Clear();
            sanctuary.Repeating();
            
        }
        
        void TestAnimals()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("              The current population:");
            Console.WriteLine("--------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Habitat habs in arkOne.HabitatList)
            {
                habs.SumAnimals();
                Console.Write(habs.HabitatName.PadRight(18));
                foreach (KeyValuePair<string, int> x in habs.AnimalDict)
                {
                    string tempString = (x.Key + "-" + x.Value).PadRight(15);
                    Console.Write(tempString);
                    //Console.Write(x.Key + "(");
                    //Console.Write(x.Value + ") ");
                }
                Console.WriteLine();
            }
        }
        void TestSumReqRes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("                 Required Resources");
            Console.WriteLine("--------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Zone               Energy   Heat   Food   Water   Oxigen");
            foreach (Habitat member in arkOne.HabitatList)
            {
                Console.Write(member.HabitatName.ToString().PadRight(19));
                Console.Write(member.SumReqEnergy.ToString().PadRight(9));
                Console.Write(member.SumReqHeat.ToString().PadRight(7));
                Console.Write(member.SumReqFood.ToString().PadRight(7));
                Console.Write(member.SumReqWater.ToString().PadRight(8));
                Console.WriteLine(member.SumReqOxigen.ToString().PadRight(8));
            }
        }
        void TestResGenerators()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("                 Running facilities");
            Console.WriteLine("--------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Heatcollectors".PadRight(19) + arkOne.HeatCollectors.Count + " block, Load: " + arkOne.HeatLoad + " %");
            Console.WriteLine("Solarpanels".PadRight(19) + arkOne.SolarPanels.Count + " block, Load: " + arkOne.EnergyLoad + " %");
            Console.WriteLine("Foodreplicators".PadRight(19) + arkOne.FoodReplicators.Count + " block, Load: " + arkOne.FoodLoad + " %");
            Console.WriteLine("Oxigen generators".PadRight(19) + arkOne.OxigenGenerators.Count + " block, Load: " + arkOne.OxigenLoad + " %");
            Console.WriteLine("Water filters: ".PadRight(19) + arkOne.WaterFilters.Count + " block, Load: " + arkOne.WaterLoad + " %");

        }
        void TestPopulate()
        {
            for (int i = 0; i < 10; i++)
            {
                arkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                arkOne.AddNewAnimal("Panda", "Herbivore", "Rainforest");
                arkOne.AddNewAnimal("Chimp", "Omnivore", "Rainforest");
                arkOne.AddNewAnimal("Zebra", "Herbivore", "Savannah");
                arkOne.AddNewAnimal("Lion", "Carnivore", "Savannah");
                arkOne.AddNewAnimal("Antilop", "Herbivore", "Savannah");
                arkOne.AddNewAnimal("Wolf", "Carnivore", "Temperate Forest");
                arkOne.AddNewAnimal("Beaver", "Herbivore", "Temperate Forest");
                arkOne.AddNewAnimal("Bald Eagle", "Carnivore", "Temperate Forest");
                arkOne.AddNewAnimal("Polar bear", "Carnivore", "Arctic");
                arkOne.AddNewAnimal("Seal", "Carnivore", "Arctic");
                arkOne.AddNewAnimal("Penguin", "Carnivore", "Arctic");
                arkOne.AddNewAnimal("Dolphin", "Carnivore", "Sea");
                arkOne.AddNewAnimal("Turtle", "Herbivore", "Sea");
                arkOne.AddNewAnimal("Seagull", "Herbivore", "Sea");
            }
        }
        void Repeating()
        {
            sanctuary.TestPopulate();
            while (true)
            { 
                arkOne.ResourceCycle();
                sanctuary.TestAnimals();
                sanctuary.TestSumReqRes();
                sanctuary.TestResGenerators(); 
                Console.WriteLine();
                arkOne.BirthDay();
                arkOne.Dying();
                //arkOne.NaturalDeath();
                Thread.Sleep(100);
                Console.Clear();     
            }
        }
    }
}
