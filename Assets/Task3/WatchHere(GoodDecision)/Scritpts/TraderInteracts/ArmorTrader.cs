using Task3.Interfaces;
using UnityEngine;

namespace Task3.TraderInteracts
{
    public class ArmorTrader : ITraderInteraction
    {
        public void Interact()
        {
            Debug.Log("Я могу предложить тебе огромный ассортимент брони");
        }
    }
}