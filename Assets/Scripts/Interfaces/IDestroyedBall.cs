using Scripts.Balls;
using System;

namespace Scripts.Interfaces
{
    public interface IDestroyedBall : ISpawning
    {
        public event Action<Ball> Destroyed;
    }
}