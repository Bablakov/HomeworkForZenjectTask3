using UnityEngine;
using Task3BadDecision.Interfaces;

namespace Task3BadDecision.Iteraction
{
    public class MoneyInteraction : ITraderInteraction
    {
        public bool DeterminePossibilityInteraction(ITradable tradable)
        {
            if (tradable.Money <= 10)
            {
                Debug.Log("Прости, но у тебя слишком мало денег, чтобы купить что-то");
                return false;
            }
            else
            {
                Debug.Log("У тебя достаточно денег, добро пожаловать");
                return true;
            }
        }
    }
}