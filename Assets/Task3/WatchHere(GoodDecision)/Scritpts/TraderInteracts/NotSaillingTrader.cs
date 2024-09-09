using Task3.Interfaces;
using UnityEngine;

namespace Task3.TraderInteracts
{
    public class NotSaillingTrader : ITraderInteraction
    {
        public void Interact()
        {
            Debug.Log("Ой, извини, но я не торгую с игроком");
        }
    }
}