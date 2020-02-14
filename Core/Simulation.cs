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
        public void LifeCycle(Program p, int cycleTime) // Running the simulation
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                p.arkOne.ResourceCycle();
                ShowAnimals(p);
                ShowRequiredResources(p);
                ShowResourceGenerators(p);
                p.arkOne.BirthDay();
                p.arkOne.Dying();
                Thread.Sleep(cycleTime);
            }
        }
        void ShowAnimals(Program p) // Showing the informations of the population by zones
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
        void ShowRequiredResources(Program p) //Showing the required resources by zones
        {
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Required Resources:");
            WriteLineBlue("Zone                  Energy(kW)   Heat(kJ)   Food(unit)   Water(m3)   Oxigen(m3)");
            foreach (Habitat member in p.arkOne.GetHabitats())
            {
                Console.Write(member.HabitatName.ToString().PadRight(19));
                Console.Write(member.SumReqEnergy.ToString().PadLeft(9));
                Console.Write(member.SumReqHeat.ToString().PadLeft(11));
                Console.Write(member.SumReqFood.ToString().PadLeft(11));
                Console.Write(member.SumReqWater.ToString().PadLeft(14));
                Console.WriteLine(member.SumReqOxigen.ToString().PadLeft(13));
            }
        }
        void ShowResourceGenerators(Program p) // Showing the current state of the supporting facilities
        {
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Running Facilities:");
            Console.WriteLine("Heatcollectors".PadRight(19) + p.arkOne.HeatCollectors.Count + " block, Load: " + p.arkOne.HeatLoad + " %");
            Console.WriteLine("Solarpanels".PadRight(19) + p.arkOne.SolarPanels.Count + " block, Load: " + p.arkOne.EnergyLoad + " %");
            Console.WriteLine("Foodreplicators".PadRight(19) + p.arkOne.FoodReplicators.Count + " block, Load: " + p.arkOne.FoodLoad + " %");
            Console.WriteLine("Oxigen generators".PadRight(19) + p.arkOne.OxigenGenerators.Count + " block, Load: " + p.arkOne.OxigenLoad + " %");
            Console.WriteLine("Water filters: ".PadRight(19) + p.arkOne.WaterFilters.Count + " block, Load: " + p.arkOne.WaterLoad + " %");
            WriteLineBlue("--------------------------------------------------------------------------------------------------------------");
            WriteLineBlue("Messages:");
        }
    }
}
