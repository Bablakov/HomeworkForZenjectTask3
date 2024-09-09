using Task3.Interfaces;
using UnityEngine;

namespace Task3.Traders
{
    public class Trader : MonoBehaviour
    {
        private ITraderInteraction _traderInteract;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITradable tradable))
                _traderInteract.Interact();
        }

        public void SetTraderInteract(ITraderInteraction traderInteract)
        {
            _traderInteract = traderInteract;
        }
    }
}