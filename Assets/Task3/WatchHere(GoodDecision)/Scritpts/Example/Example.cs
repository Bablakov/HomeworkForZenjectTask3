using Task3.TraderInteracts;
using Task3.Traders;
using Task3.Players;
using UnityEngine;
using General.Input;

namespace Task3.Example
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Trader _trader;
        [SerializeField] private Player _player;

        private void Awake()
        {
            PlayerInitialize();
            TraderInitialize();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Теперь я торгую фруктами");
                _trader.SetTraderInteract(new FruitTrader());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Теперь я не торгую");
                _trader.SetTraderInteract(new NotSaillingTrader());
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Теперь я торгую бронёй");
                _trader.SetTraderInteract(new ArmorTrader());
            }
        }

        private void PlayerInitialize()
        {
            GameInput gameInput = new GameInput();
            _player.Initialize(gameInput);
        }

        private void TraderInitialize()
        {
            Debug.Log("Теперь я торгую фруктами");
            _trader.SetTraderInteract(new FruitTrader());
        }
    }
}