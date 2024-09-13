using System;

namespace Scripts.Interfaces
{
    public interface IDestroyed : ISpawning
    {
        public event Action Destroyed;
    }
}