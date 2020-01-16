﻿using System;
namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public class Animal : Species
    {
        static int ID { get; set;} 
        // Constructor
        public Animal(String SpeciesName, String Type, String IdealEnvironment)
        {
            ID += 1;
            OwnName = ID.ToString();
            ReqSpace = 1000;
            ReqHeatUnit = 2;
            ReqOxigenUnit = 2;
            ReqFoodUnit = 2;
            ReqWaterUnit = 2;
            ReqEnergyUnit = 2;
            MaximumAge = 5000;
            this.SpeciesName = SpeciesName;
            this.Type = Type;
            this.IdealEnvironment = IdealEnvironment;
        }
        // Methods
        public override string ToString()
        {
            return OwnName + " " + SpeciesName + " " + Type + " " + IdealEnvironment;
        }
        public override void Sickness()
        {
            SomethingHappens = rnd.Next(1,200);
            if (SomethingHappens == 200)
            {
                Dead = true;
            }
            else if (SomethingHappens > 190 & SomethingHappens < 200)
            {
                MaximumAge -= 100;
            }
        }
    }
}