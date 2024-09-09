using UnityEngine;

namespace Task3BadDecision.Traders
{
    public class NotSaillingTrader : Trader
    {
        protected override void Trade()
        {
            Debug.Log("Ой, извини, но я не торгую с игроком");
        }
    }
}