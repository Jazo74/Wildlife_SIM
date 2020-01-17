using System;
using System.Threading;


namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    class Program

    {
        // Habitat Rainforest = new Habitat("Rainforest");
        public ResourcePool ArkOne = new ResourcePool("new");
        
        static void Main(string[] args)
        {
            ResourcePool ArkOne = new ResourcePool("new");

            Console.Clear();
            test();
        }

        public static void test()
        {
            Repeating();   
        }
        void TestAnimals()
        {
            foreach (Habitat habs in ArkOne.HabitatList)
            {
                foreach (Animal member in habs.AnimalList)
                {
                    Console.Write(member.OwnName + " / ");
                    Console.WriteLine(member.SpeciesName);
                }
            }
        }
        void TestSumReqRes()
        {
            Console.WriteLine("Req Resources.    Energy Heat Food Water Oxigen");
            Console.Write(ArkOne.HabitatName.ToString().PadRight(18));
            Console.Write(member.SumReqEnergy.ToString().PadRight(7));
            Console.Write(member.SumReqHeat.ToString().PadRight(5));
            Console.Write(member.SumReqFood.ToString().PadRight(5));
            Console.Write(member.SumReqWater.ToString().PadRight(6));
            Console.WriteLine(member.SumReqOxigen.ToString().PadRight(6));
            
        }
        void Repeating()
        {
            for (int i = 0; i < 10; i++)
            {
                ArkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Chimp", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Dolphin", "Carnivore", "Sea");
                //TestAnimals();
                TestSumReqRes();
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        

    }
}
