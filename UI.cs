using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using static codecool.miskolc.zoltan_jarmy.sanctuary.ui.Toolbox;
using codecool.miskolc.zoltan_jarmy.sanctuary.core;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.ui
{
    public class UI
    {
        Simulation life;
        public UI()
        {
            life = new Simulation();
        }
        public void Start(Program p)
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
            if (File.Exists("sanctuary.xml") == false)
            {
                WriteLineRed("Not available");
            }
            else
            {
                WriteLineGreen("Available");
            }
            Console.WriteLine();
            Console.WriteLine("(1) Managing Habitat zones");
            Console.WriteLine("(2) Managing life forms");
            Console.WriteLine("(3) Starting / Resuming the normal life");
            Console.WriteLine("(4) Hibernating process");
            Console.WriteLine("(5) Awakening process");
            Console.WriteLine("(6) Statistics panel");
            Console.WriteLine("(7) About US");
            Console.WriteLine("(0) Exit Program");
            Console.WriteLine();
        }
        public void SubMenuHabitat()
        {
            Console.Clear();
            WriteLineBlue("Habitat panel (please choose a number)");
            Console.WriteLine();
            Console.WriteLine("(1) Building a new Habitat zone");
            Console.WriteLine("(2) Information about the current zones");
            Console.WriteLine("(3) Recalibrating the zones");
            Console.WriteLine("(4) Demolish a zone");
            Console.WriteLine("(0) Back to the main panel");
            Console.WriteLine();
        }
        public void SubMenuAnimal()
        {
            Console.Clear();
            WriteLineBlue("Animals panel (please choose a number)");
            Console.WriteLine();
            Console.WriteLine("(1) Arriving a new animal");
            Console.WriteLine("(2) Informations about an animal");
            Console.WriteLine("(3) Informations about all animal");
            Console.WriteLine("(4) Update the informations of the animal");
            Console.WriteLine("(5) Relocating an animal");
            Console.WriteLine("(0) Back to the main panel");
            Console.WriteLine();
        }
        public void SubMenuStatistics()
        {
            Console.Clear();
            WriteLineBlue("Statistics panel (please choose a number)");
            Console.WriteLine();
            Console.WriteLine("(1) Information about the Habitats");
            Console.WriteLine("(2) Information about an animals");
            Console.WriteLine("(0) Back to the main panel");
            Console.WriteLine();
        }

        public bool Choice(Program p, Simulation life)
        {
            string choice;
            choice = InputAny("Choose an option: ");
            switch (choice)
            {
                case "1":
                    bool loopH = true;
                    while (loopH)
                    {
                        SubMenuHabitat();
                        loopH = SubChoiceHabitat(p);
                    }
                    break;
                case "2":
                    bool loopA = true;
                    while (loopA)
                    {
                        SubMenuAnimal();
                        loopA = SubChoiceAnimal(p);
                    }
                    break;
                case "3":
                    life.LifeCycle(p);
                    break;
                case "4":
                    p.arkOne.SerializeMyList();
                    WriteLineGreen("The Serialization has completed.");
                    Thread.Sleep(1000);
                    break;
                case "5":
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
                case "6":
                    bool loopS = true;
                    while (loopS)
                    {
                        SubMenuStatistics();
                        loopS = SubChoiceStatistics(p);
                    }
                    break;
                case "7":
                    return true;
                case "0":
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
            choice = InputAny("Choose an option: ");
            Console.WriteLine();
            switch (choice)
            {
                case "1": // Creating new habitat
                    try
                    {
                        string newName = InputAny("The name of the new Habitat?: ");
                        if (p.arkOne.HabitatIsExist(newName))
                        {
                            throw new HabitatIsExistException();
                        }
                        p.arkOne.CreatingAHabitat(newName);
                        WriteLineGreen("Tha habitat has been built.");
                    }
                    catch (HabitatIsExistException)
                    {
                        WriteLineRed("This Habitat is already exist");
                    }
                    Thread.Sleep(2000);
                    break;
                case "2": // Displaying Habitats
                    foreach (Habitat habitat in p.arkOne.GetHabitats())
                    {
                        WriteBlue(habitat.HabitatName + ": ");
                        Console.WriteLine(habitat.AnimalList.Count.ToString() + " animals live in this Habitat.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "3": // Renaming a Habitat
                    try
                    {
                        string habitatName = InputAny("The name of the Habitat?: ");
                        string newName = InputAny("The new name of the Habitat?: ");
                        if (p.arkOne.HabitatIsExist(newName)) { throw new HabitatIsExistException(); }
                        List<Habitat> habitats = p.arkOne.GetHabitats();
                        foreach (Habitat habitat in habitats)
                        {
                            if (!p.arkOne.HabitatIsExist(newName))
                            {
                                habitat.SetHabitatName(newName);
                                WriteLineGreen("The Habitat has been renamed.");
                            }
                        }
                    }
                    catch (HabitatNotExistException)
                    {
                        WriteLineRed("This Habitat is not exist");
                    }
                    catch (HabitatIsExistException)
                    {
                        WriteLineRed("This Habitat is already exist");
                    }
                    Thread.Sleep(2000);
                    break;
                case "4": // Deleting a Habitat
                    try
                    {
                        p.arkOne.RemovingAHabitat(InputAny("The name of the habitat?: "));
                        WriteLineGreen("The Habitat has been demolished.");
                    }
                    catch (HabitatNotExistException)
                    {
                        WriteLineRed("This Habitat is not exist");
                    }
                    catch (NotEmptyHabitatException)
                    {
                        WriteLineRed("You can not demolish because animals live there");
                    }
                    Thread.Sleep(1000);
                    break;
                case "0":
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
            choice = InputAny("Choose an option: ");
            Console.WriteLine();
            switch (choice)
            {
                case "1": //Adding new animal
                    string speciesName;
                    string habitatName;
                    string type;
                    speciesName = InputAny("What is the species?: ");
                    habitatName = InputAny("What is the optimal habitat zone?: ");
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
                case "2": //Listing an animal
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

                case "3": //Listing all animal
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
                case "4": //Update an animal
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
                case "5": //Removing an animal
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
                case "0":
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
            choice = InputAny("Choose an option: ");
            Console.WriteLine();
            switch (choice)
            {
                case "1":
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
                case "2":
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
                case "0":
                    return false;
                default:
                    WriteLineRed("Wrong option!");
                    break;
            }
            return true;
        }
    }
}
