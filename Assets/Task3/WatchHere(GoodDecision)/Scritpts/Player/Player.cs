using General.Input;
using Task3.Interfaces;
using UnityEngine;

namespace Task3.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, ITradable
    {
        [SerializeField, Range(0, 10)] private float _speed;

        private GameInput _gameInput;
        private CharacterController _characterController;

        public void Initialize(GameInput gameInput)
        {
            _gameInput = gameInput;

            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_gameInput.CanMovement)
                _characterController.Move(_gameInput.GetDirectionMovememt() * _speed * Time.deltaTime);
        }
    }
}