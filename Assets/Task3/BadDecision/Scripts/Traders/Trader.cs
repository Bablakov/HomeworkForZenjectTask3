using UnityEngine;
using Task3BadDecision.Interfaces;

namespace Task3BadDecision.Traders
{
    public abstract class Trader : MonoBehaviour
    {
        private ITraderInteraction _traderInteraction;

        public void Initialize(ITraderInteraction traderIteraction)
        {
            _traderInteraction = traderIteraction;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITradable tradable))
            {
                if (_traderInteraction.DeterminePossibilityInteraction(tradable))
                    Trade();
            }
        }

        protected abstract void Trade();
    }
}