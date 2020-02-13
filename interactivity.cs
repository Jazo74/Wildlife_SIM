using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using static codecool.miskolc.zoltan_jarmy.sanctuary.ui.Toolbox;
using codecool.miskolc.zoltan_jarmy.sanctuary.core;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public class interactivity
    {
        Simulation life;
        public interactivity()
        {
            life = new Simulation();
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
            WriteLineBlue("Welcome to SANCTUARY, the last hope of the animals! (please choose a number)");
            Console.WriteLine();
            Console.Write("Hibernation status    ");
            if (File.Exists("myxml.xml") == false)
            {
                WriteLineRed("Not available");
            }
            else
            {
                WriteLineGreen("Available");
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
            WriteLineBlue("Habitat panel (please choose a number)");
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
            WriteLineBlue("Animals panel (please choose a number)");
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
            WriteLineBlue("Statistics panel (please choose a number)");
            Console.WriteLine();
            Console.WriteLine("(0) Information about the Habitats");
            Console.WriteLine("(1) Information about an animals");
            Console.WriteLine("(2) Back to the main panel");
            Console.WriteLine();
        }

        public bool Choice(Program p, Simulation life)
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
                    life.LifeCycle(p);
                    break;
                case "3":
                    p.arkOne.SerializeMyList();
                    WriteLineGreen("The Serialization has completed.");
                    Thread.Sleep(1000);
                    break;
                case "4":
                    try
                    {
                        p.arkOne.DeSerializeMyList();
                        WriteLineGreen("The DeSerialization has completed.");
                    }
                    catch (FileNotExistException)
                    {
                        WriteLineRed("The file not exist!");
                    }
                    Thread.Sleep(1000);
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
                    return true;
                case "7":
                    WriteLineGreen("Thank you for using our service! Have a nice day citizen!");
                    return false;
                default:
                    WriteLineRed("Wrong option!");
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
                    string newName = InputAny("The name of the new Habitat?: ");
                    if (!p.arkOne.HabitatIsExist(newName, p.arkOne.GetHabitats()))
                    {
                        WriteLineRed("This habitat is already exist!");
                    }
                    else
                    {
                        p.arkOne.CreatingAHabitat(newName);
                        WriteLineGreen("Tha habitat has been built.");
                    }
                    Thread.Sleep(2000);
                    break;
                case "1": // Displaying Habitats
                    foreach (Habitat habitat in p.arkOne.GetHabitats())
                    {
                        Console.Write(habitat.HabitatName + ": ");
                        Console.WriteLine(habitat.AnimalList.Count.ToString() + " animals live in this Habitat.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "2": // Renaming a Habitat
                    bool found1 = false;
                    string zoneName1 = InputAny("The name of the Habitat?: ");
                    newName = InputAny("What will be the new name of the Habitat?: ");
                    foreach (Habitat zone in p.arkOne.GetHabitats())
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
                                foreach (Habitat zone2 in p.arkOne.GetHabitats())
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
                    string zoneName2 = InputAny("The name of the Habitat, you want the demolish ?: ");
                    foreach (Habitat zone in p.arkOne.GetHabitats())
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
                        for (int index = p.arkOne.GetHabitats().Count - 1;  index >= 0; index--)
                        {
                            if (p.arkOne.GetHabitats()[index].HabitatName == zoneName2)
                            {
                                Console.WriteLine("The " + p.arkOne.GetHabitats()[index].HabitatName + " zone has removed");
                                p.arkOne.GetHabitats().RemoveAt(index);
                                Thread.Sleep(2000);
                            }
                        }
                    }
                    break;
                case "4":
                    return false;
                default:
                    WriteLineRed("Wrong option!");
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
                case "0": //Adding new animal
                    string speciesName;
                    string habitatName;
                    string type;
                    speciesName = InputAny("What is the species?: ");
                    habitatName = InputAny("What is the optimal habitat zone ?: ");
                    while (true)
                    {
                        type = InputAny("What kind of animal is this? (herbivore, carnivore, omnivore): ");
                        if (type.ToLower() == "herbivore" || type.ToLower() == "carnivore" || type.ToLower() == "omnivore")
                        {
                            break;
                        }
                    }
                    try
                    {
                        p.arkOne.AddNewAnimal(speciesName, type, habitatName);
                    }
                    catch (HabitatNotExistException)
                    {
                        WriteLineRed("This Habitat is not exist. You should build it first!");
                        Thread.Sleep(2000);
                    }
                    break;
                case "1": //Listing an animal
                    Animal animaL;
                    try
                    {
                        animaL = p.arkOne.FoundAnimal(InputAny("What is the ID of the animal?: "));
                        Console.WriteLine("The animal ID is: " + animaL.OwnName);
                        Console.WriteLine("The animal species is: " + animaL.SpeciesName);
                        Console.WriteLine("Required energy: " + animaL.ReqEnergyUnit);
                        Console.WriteLine("Required heat: " + animaL.ReqHeatUnit);
                        Console.WriteLine("Required oxigen: " + animaL.ReqOxigenUnit);
                        Console.WriteLine("Required water: " + animaL.ReqWaterUnit);
                        Console.WriteLine("Required food: " + animaL.ReqFoodUnit);
                    }
                    catch (AnimalNotExistException)
                    {
                        WriteLineRed("There is no such animal...");
                    }
                    InputAny("Press any key to continue...");
                    break;

                case "2": //Listing all animal
                    foreach (Habitat habitat in p.arkOne.GetHabitats())
                    {
                        WriteLineBlue(habitat.HabitatName);
                        foreach (Animal animal in habitat.AnimalList)
                        {
                            Console.Write("ID: " + animal.OwnName.PadRight(4));
                            Console.Write(" " + animal.SpeciesName.PadRight(15));
                            Console.Write(" RE: " + animal.ReqEnergyUnit);
                            Console.Write(" RH: " + animal.ReqHeatUnit);
                            Console.Write(" RO: " + animal.ReqOxigenUnit);
                            Console.Write(" RW: " + animal.ReqWaterUnit);
                            Console.WriteLine(" RF: " + animal.ReqFoodUnit);
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3": //Update an animal
                    try
                    {
                        animaL = p.arkOne.FoundAnimal(InputAny("What is the ID of the animal?: "));
                        Console.WriteLine("The animal ID is: " + animaL.OwnName);
                        Console.WriteLine("The animal species is: " + animaL.SpeciesName);
                        Console.WriteLine("Required energy: " + animaL.ReqEnergyUnit);
                        Console.WriteLine("Required heat: " + animaL.ReqHeatUnit);
                        Console.WriteLine("Required oxigen: " + animaL.ReqOxigenUnit);
                        Console.WriteLine("Required water: " + animaL.ReqWaterUnit);
                        Console.WriteLine("Required food: " + animaL.ReqFoodUnit);
                        Console.WriteLine();
                        WriteLineRed("The parameters should be between 1 and 4");
                        Console.WriteLine();
                        animaL.ReqEnergyUnit = InputIntBetween("New required energy?: ", 1, 4);
                        animaL.ReqHeatUnit = InputIntBetween("New required heat ?: ", 1, 4);
                        animaL.ReqOxigenUnit = InputIntBetween("New required oxigen?: ", 1, 4);
                        animaL.ReqWaterUnit = InputIntBetween("New required water?: ", 1, 4);
                        animaL.ReqFoodUnit = InputIntBetween("New required food?: ", 1, 4);
                        Console.WriteLine("The parameters of this animal has updated");
                    }
                    catch (AnimalNotExistException)
                    {
                        WriteLineRed("There is no such animal...");
                    }
                    Thread.Sleep(2000);
                    break;
                case "4": //Removing an animal
                    try
                    {
                        p.arkOne.RelocateAnimal(InputAny("What is the ID of the animal you want to relocate?: "));
                        WriteLineGreen("The animal has relocated.");
                    }
                    catch (AnimalNotExistException)
                    {
                        WriteLineRed("There is no such animal...");
                    }
                    Thread.Sleep(2000);
                    break;
                case "5":
                    return false;
                default:
                    WriteLineRed("Wrong option!");
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
                    foreach (Habitat habitat in p.arkOne.GetHabitats())
                    {
                        habitat.SumAnimals();
                        WriteBlue(habitat.HabitatName);
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
                    foreach (Habitat habitat in p.arkOne.GetHabitats())
                    {
                        habitat.SumAnimals();
                        WriteLineBlue(habitat.HabitatName.ToUpper() + " : ");
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
                    WriteLineRed("Wrong option!");
                    break;
            }
            return true;
        }
    }
}
