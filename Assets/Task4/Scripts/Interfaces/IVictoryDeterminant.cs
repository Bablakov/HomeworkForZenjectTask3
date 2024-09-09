using System;

namespace Task4.Interfaces
{
    public interface IVictoryDeterminant
    {
        public event Action WonGame;
        public event Action LostGame;
    }
}
