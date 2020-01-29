using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using codecool.miskolc.zoltan_jarmy.sanctuary.core;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public class interactivity
    {
        Lifecycle life;
        public interactivity()
        {
            life = new Lifecycle();
        }
        public void UI(Program p)
        {
            bool loop = true;
            while (loop)
            {
                Menu();
                loop = Choice(p,life);
            }
            
        }
        static public void Menu() // main menu 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to SANCTUARY, the last hope of the animals! (please choose a number)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Hibernation status    ");
            if (File.Exists("myxml.xml") == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Not available");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Available");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.WriteLine("(0) Managing Habitat zones");
            Console.WriteLine("(1) Managing life forms");
            Console.WriteLine("(2) Starting / Resuming the normal life");
            Console.WriteLine("(3) Hibernating process");
            Console.WriteLine("(4) Awakening process");
            Console.WriteLine("(5) Statistics panel");
            Console.WriteLine("(6) About US");
            Console.WriteLine("(7) Exit Program");
            Console.WriteLine();
        }
        public void SubMenuHabitat()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Habitat panel (please choose a number)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("(0) Building a new Habitat zone");
            Console.WriteLine("(1) Information about the current zones");
            Console.WriteLine("(2) Recalibrating the zones");
            Console.WriteLine("(3) Demolish a zone");
            Console.WriteLine("(4) Back to the main panel");
            Console.WriteLine();
        }
        public void SubMenuAnimal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Animals panel (please choose a number)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("(0) Arriving a new animal");
            Console.WriteLine("(1) Informations about an animal");
            Console.WriteLine("(2) Informations about all animal");
            Console.WriteLine("(3) Update the informations of the animal");
            Console.WriteLine("(4) Relocating an animal");
            Console.WriteLine("(5) Back to the main panel");
            Console.WriteLine();
        }
        public void SubMenuStatistics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Statistics panel (please choose a number)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("(0) Information about the Habitats");
            Console.WriteLine("(1) Information about an animals");
            Console.WriteLine("(2) Back to the main panel");
            Console.WriteLine();
        }

        public bool Choice(Program p, Lifecycle life)
        {
            string choice;
            choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "0":
                    bool loopH = true;
                    while (loopH)
                    {
                        SubMenuHabitat();
                        loopH = SubChoiceHabitat(p);
                    }
                    break;
                case "1":
                    bool loopA = true;
                    while (loopA)
                    {
                        SubMenuAnimal();
                        loopA = SubChoiceAnimal(p);
                    }
                    break;
                case "2":
                    life.Cycle(p);
                    break;
                case "3":
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The stored datas has erased!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "5":
                    bool loopS = true;
                    while (loopS)
                    {
                        SubMenuStatistics();
                        loopS = SubChoiceStatistics(p);
                    }
                    break;
                case "6":
                    
                    return false;
                case "7":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for using our service! Have a nice day citizen!");
                    Console.ForegroundColor = ConsoleColor.White;
                    //Thread.Sleep(1000);
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return true;
        }
        public bool SubChoiceHabitat(Program p)
        {
            string choice;
            choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "0": // Creating new habitat
                    string newName;
                    bool found2 = false;
                    Console.Write("The name of the new Habitat?: ");
                    newName = Console.ReadLine();
                    foreach (Habitat zone in p.arkOne.HabitatList)
                    {
                        if (zone.HabitatName == newName)
                        {
                            Console.Write("Two zones with same name is not allowed!");
                            Thread.Sleep(2000);
                            found2 = true;
                            break;
                        }
                    }
                    if (found2 == false)
                    {
                        p.arkOne.CreatingAHabitat(newName);
                    }
                    break;
                case "1": // Displaying Habitats
                    foreach (Habitat zone in p.arkOne.HabitatList)
                    {
                        Console.Write(zone.HabitatName + ": ");
                        Console.WriteLine(zone.AnimalList.Count.ToString() + " animals live in this Habitat.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "2": // Renaming a Habitat
                    bool found1 = false;
                    Console.Write("The name of the Habitat?: ");
                    string zoneName1 = Console.ReadLine();
                    Console.Write("What will be the new name of the Habitat?: ");
                    newName = Console.ReadLine();
                    foreach (Habitat zone in p.arkOne.HabitatList)
                    {
                        if (zone.HabitatName == zoneName1)
                        {
                            if (zone.AnimalList.Count > 0)
                            {
                                Console.WriteLine("You can't remodel this Habitat, because " + zone.AnimalList.Count.ToString() + " animals live theres");
                                found1 = true;
                                break;
                            }
                            else
                            {
                                foreach (Habitat zone2 in p.arkOne.HabitatList)
                                {
                                    if (zone2.HabitatName == newName)
                                    {
                                        Console.Write("Two zones with same name is not allowed!");
                                        Thread.Sleep(2000);
                                        found1 = true;
                                        break;
                                    }
                                }
                                zone.HabitatName = newName;
                                found1 = true;
                            }
                        }
                        
                    }
                    if (found1 == false)
                    {
                        Console.WriteLine("There is no habitat with this Name.");
                        Thread.Sleep(2000);
                    }
                    break;
                case "3": // Deleting a Habitat
                    bool killCommand = false;
                    bool found = false;
                    Console.Write("The name of the Habitat, you want the demolish?: ");
                    string zoneName2 = Console.ReadLine();
                    foreach (Habitat zone in p.arkOne.HabitatList)
                    {
                        if (zone.HabitatName == zoneName2)
                        {
                            if (zone.AnimalList.Count > 0)
                            {
                                Console.WriteLine("You can't demolish this Habitat, because " + Convert.ToString(zone.AnimalList.Count) +" animal(s) live(s) theres");
                                found = true;
                                Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                found = true;
                                killCommand = true;
                            }
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("There in no Habitat with this name!");
                        Thread.Sleep(2000);
                        break;
                    }
                    if (killCommand == true)
                    {
                        for (int index = p.arkOne.HabitatList.Count - 1;  index >= 0; index--)
                        {
                            if (p.arkOne.HabitatList[index].HabitatName == zoneName2)
                            {
                                Console.WriteLine("The " + p.arkOne.HabitatList[index].HabitatName + " zone has removed");
                                p.arkOne.HabitatList.RemoveAt(index);
                                Thread.Sleep(2000);
                            }
                        }
                    }
                    break;
                case "4":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return true;
        }
        public bool SubChoiceAnimal(Program p)
        {
            string choice;
            choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "0":
                    string speciesName;
                    string habitatName;
                    string type;
                    Console.Write("What is the species?: ");
                    speciesName = Console.ReadLine();
                    Console.Write("What is the optimal habitat zone?: ");
                    habitatName = Console.ReadLine();
                    Console.Write("What kind of animal is this? (herbivore, carnivore, omnivore): ");
                    type = Console.ReadLine();
                    p.arkOne.AddNewAnimal(speciesName, type, habitatName);
                    break;
                case "1":
                    string animalNr;
                    bool found = false;
                    Console.Write("What is the ID of the animal?: ");
                    animalNr = Console.ReadLine();
                    foreach (Habitat habitat in p.arkOne.HabitatList)
                    {
                        foreach (Animal animal in habitat.AnimalList)
                        {
                            if (animal.OwnName == animalNr)
                            {
                                Console.WriteLine("The animal ID is: " + animal.OwnName);
                                Console.WriteLine("The animal species is: " + animal.SpeciesName);
                                Console.WriteLine("Required energy: " + animal.ReqEnergyUnit);
                                Console.WriteLine("Required heat: " + animal.ReqHeatUnit);
                                Console.WriteLine("Required oxigen: " + animal.ReqOxigenUnit);
                                Console.WriteLine("Required water: " + animal.ReqWaterUnit);
                                Console.WriteLine("Required food: " + animal.ReqFoodUnit);
                                found = true;
                            }
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("There is no such animal...");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    foreach (Habitat habitat in p.arkOne.HabitatList)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(habitat.HabitatName);
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (Animal animal in habitat.AnimalList)
                        {
                            Console.Write("ID: " + animal.OwnName.PadRight(4));
                            Console.Write(" " + animal.SpeciesName.PadRight(15));
                            Console.Write(" RE: " + animal.ReqEnergyUnit);
                            Console.Write(" RH: " + animal.ReqHeatUnit);
                            Console.Write(" RO: " + animal.ReqOxigenUnit);
                            Console.Write(" RW: " + animal.ReqWaterUnit);
                            Console.WriteLine(" RF: " + animal.ReqFoodUnit);
                            found = true;
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    string animalNm;
                    bool found1 = false;
                    Console.Write("What is the ID of the animal?: ");
                    animalNm = Console.ReadLine();
                    foreach (Habitat habitat in p.arkOne.HabitatList)
                    {
                        foreach (Animal animal in habitat.AnimalList)
                        {
                            if (animal.OwnName == animalNm)
                            {
                                Console.WriteLine("The animal ID is: " + animal.OwnName);
                                Console.WriteLine("The animal species is: " + animal.SpeciesName);
                                Console.WriteLine("Required energy: " + animal.ReqEnergyUnit);
                                Console.WriteLine("Required heat: " + animal.ReqHeatUnit);
                                Console.WriteLine("Required oxigen: " + animal.ReqOxigenUnit);
                                Console.WriteLine("Required water: " + animal.ReqWaterUnit);
                                Console.WriteLine("Required food: " + animal.ReqFoodUnit);
                                found1 = true;
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The parameter should be between 1 and 4! Wrong inputs will be overwrited to the nominal (2)");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.Write("New required energy?: ");
                                animal.ReqEnergyUnit = CheckInput();
                                Console.Write("New required heat?: ");
                                animal.ReqHeatUnit = CheckInput();
                                Console.Write("New required oxigen?: ");
                                animal.ReqOxigenUnit = CheckInput();
                                Console.Write("New required water?: ");
                                animal.ReqWaterUnit = CheckInput();
                                Console.Write("New required food?: ");
                                animal.ReqFoodUnit = CheckInput();
                            }
                        }
                    }
                    if (!found1)
                    {
                        Console.WriteLine("There is no such animal...");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("What is the ID of the animal you want to relocate?: ");
                    if (!p.arkOne.RelocateAnimal(Console.ReadLine()))
                    {
                        Console.WriteLine("There is no such animal...");
                        Thread.Sleep(2000);
                    }
                    break;
                case "5":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return true;
        }
        public bool SubChoiceStatistics(Program p)
        {
            string choice;
            choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "0":
                    foreach (Habitat habitat in p.arkOne.HabitatList)
                    {
                        habitat.SumAnimals();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(habitat.HabitatName);
                        Console.ForegroundColor = ConsoleColor.White;
                        int count = 0;
                        foreach (KeyValuePair<string, int> items in habitat.AnimalDict)
                        {
                            count += items.Value;
                        }
                        Console.WriteLine(" has " + count + " amimals");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "1":
                    foreach (Habitat habitat in p.arkOne.HabitatList)
                    {
                        habitat.SumAnimals();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(habitat.HabitatName.ToUpper() + " : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (KeyValuePair<string, int> items in habitat.AnimalDict)
                        {
                            Console.Write(items.Key.ToLower() + " : ");
                            Console.WriteLine(items.Value);
                        }

                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return true;
        }
        private int CheckInput()
        {
            int outNumber;
            string input = Console.ReadLine();
            if (int.TryParse(input, out outNumber))
            {
                if (outNumber < 5 && outNumber > 0)
                {
                    return outNumber;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" /overwrited to '2'");
                    Console.ForegroundColor = ConsoleColor.White;
                    return 2;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" /overwrited to '2'");
                Console.ForegroundColor = ConsoleColor.White;
                return 2;
            }
        }
    }
}
