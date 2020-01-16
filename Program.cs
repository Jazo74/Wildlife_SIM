using System;
using System.Threading.Tasks;


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
            Console.Clear();
            Repeating();   
        }
        static void TestAnimals()
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
        static void TestSumReqRes()
        {
            Console.WriteLine("Req Resources.    Energy Heat Food Water Oxigen");
            
           
            foreach (Habitat member in ArkOne.HabitatList)
            {
                member.GatherAllReq();
                Console.Write(member.HabitatName.ToString().PadRight(18));
                Console.Write(member.SumReqEnergy.ToString().PadRight(7));
                Console.Write(member.SumReqHeat.ToString().PadRight(5));
                Console.Write(member.SumReqFood.ToString().PadRight(5));
                Console.Write(member.SumReqWater.ToString().PadRight(6));
                Console.WriteLine(member.SumReqOxigen.ToString().PadRight(6));
            }
        }
        static void Repeating()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(2000);
                ArkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Tiger", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Chimp", "Carnivore", "Rainforest");
                ArkOne.AddNewAnimal("Dolphin", "Carnivore", "Sea");
                //TestAnimals();
                TestSumReqRes();
                Console.Clear();
            }
        }
        

    }
}
