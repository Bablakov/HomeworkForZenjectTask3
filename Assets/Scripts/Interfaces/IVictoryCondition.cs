using System;

namespace Scripts.Interfaces
{
    public interface IVictoryCondition
    {
        public event Action<bool> Finished;
    }
}
