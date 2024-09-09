using UnityEngine;
using Task3BadDecision.Interfaces;

namespace Task3BadDecision.Iteraction
{
    internal class AgeInteraction : ITraderInteraction
    {
        public bool DeterminePossibilityInteraction(ITradable tradable)
        {
            if (tradable.Age < 18)
            {
                Debug.Log("Прости, но ты слишком мал");
                return false;
            }
            else
            {
                Debug.Log("У тебя достаточный возвраст, для торговли со мной");
                return true;
            }
        }
    }
}