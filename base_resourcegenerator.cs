namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    abstract class ResourceGenerator
    {
        // Base Properties
        String ResourceType { get; set; }
        int Capacity { get; set; }
        int Load { get; set; }
        int GeneratePerCycle { get; set; }
        int MaintenanceCycle { get; set; }
        String State { get; set; }
        // Base methods
        abstract void Maintenance;
        abstract void Start;
        abstract void Shutdown;

    }
}