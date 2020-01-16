using System;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    class Program

    {
        // static Habitat Rainforest = new Habitat("Rainforest");
        static ResourcePool ArkOne = new ResourcePool("new");

        static void Main(string[] args)
        {
            test();

        }

        public static void test()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("0 animals created");
            TestSumReqRes();
            TestAnimals();
            ArkOne.HabitatList[0].NewAnimal("Tiger", "Carnivore", "Rainforest");
            ArkOne.HabitatList[0].NewAnimal("Tiger", "Carnivore", "Rainforest");
            ArkOne.HabitatList[0].NewAnimal("Chimp", "Carnivore", "Rainforest");
            Console.WriteLine("3 animals created");
            TestAnimals();
            TestSumReqRes();
            ArkOne.HabitatList[0].RelocateAnimal("Tiger_1");
            Console.WriteLine("1 animals relocated");
            TestAnimals();
            TestSumReqRes();
            
        }
        static void TestAnimals()
        {
            foreach (Animal member in ArkOne.HabitatList[0].AnimalList)
            {
                Console.Write(member.ToString() + " / ");
                Console.WriteLine(member.SpeciesName);
            }
        }
        static void TestSumReqRes()
        {
            Console.WriteLine("Required resources");
            ArkOne.HabitatList[0].GatherAllReq();
            Console.WriteLine("Energy: "+ ArkOne.HabitatList[0].SumReqEnergy);
            Console.WriteLine("Heat: " + ArkOne.HabitatList[0].SumReqHeat);
            Console.WriteLine("Food: " + ArkOne.HabitatList[0].SumReqFood);
            Console.WriteLine("Water: " + ArkOne.HabitatList[0].SumReqWater);
            Console.WriteLine("Oxigen: " + ArkOne.HabitatList[0].SumReqOxigen);
        }
        
    }
}
