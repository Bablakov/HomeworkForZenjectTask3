using UnityEngine;

namespace Task3BadDecision.Traders
{
    public class ArmorTrader : Trader
    {
        protected override void Trade()
        {
            Debug.Log("Я могу предложить тебе огромный ассортимент брони");
        }
    }
}