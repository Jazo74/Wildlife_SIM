namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    abstract class Animal
    {
        // Base Properties
        string Type { get; set} //carnivore, herbivore, omnivore
        int ReqSpace { get; set; }
        int ReqHeatUnit { get; set; }
        int ReqOxigenUnit { get; set; }
        int ReqFoodUnit { get; set; }
        int ReqWaterUnit { get; set; }
        abstract String IdealEnvironment { get; set; }
        abstract String IdealFoodType { get; set; }
        // Base Methods
        abstract String Living();
        abstract String Eating();
    }
}