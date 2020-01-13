namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    abstract class Habitat
    {
        // Base Properties
        String EnvironmentType { get; set; }
        int Size { get; private set; }
        int ReqHeat { get; }
        int ReqOxigen { get; }
        int ReqWater { get; }
        int ReqFood { get; }
        // Calculated Properties  
        int ReqEnergy = ReqHeat + ReqOxigen;
        // Methods
        void StartHabitat;
        void HibernateHabitat;

    }

}