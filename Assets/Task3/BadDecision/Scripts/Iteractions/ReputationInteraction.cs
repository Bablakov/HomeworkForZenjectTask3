using UnityEngine;
using Task3BadDecision.Interfaces;

namespace Task3BadDecision.Iteraction
{
    public class ReputationInteraction : ITraderInteraction
    {
        public bool DeterminePossibilityInteraction(ITradable tradable)
        {
            if(tradable.Reputation <= 15)
            {
                Debug.Log("Прости, но у тебя слишком низкая репутация");
                return false;
            }
            else
            {
                Debug.Log("У тебя хорошая репутация, с тобой можно иметь дело");
                return true;
            }
        }
    }
}