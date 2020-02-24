using System;

namespace codecool.miskolc.zoltan_jarmy.sanctuary.core
{
    public interface ISimulation
    {
        public void LifeCycle(Program p, int cycleTime);
    }
}
