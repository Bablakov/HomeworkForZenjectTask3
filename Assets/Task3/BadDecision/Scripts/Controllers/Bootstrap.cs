using UnityEngine;
using Task3BadDecision.Iteraction;
using Task3BadDecision.Traders;

namespace Task3BadDecision.Controllers
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Trader _reputationTraderIteraction;
        [SerializeField] private Trader _moneyTraderIteraction;
        [SerializeField] private Trader _ageTraderIteraction;

        private void Awake()
        {
            _reputationTraderIteraction.Initialize(new ReputationInteraction());
            _moneyTraderIteraction.Initialize(new MoneyInteraction());
            _ageTraderIteraction.Initialize(new AgeInteraction());
        }
    }
}