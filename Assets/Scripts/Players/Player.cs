using Scripts.Input;
using System;
using Scripts.Balls;
using Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Scripts.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, IBallBurster, IInitializable
    {
        public event Action<Ball> BurstedBall;

        [SerializeField, Range(0, 10)] private float _speed;

        private GameInput _gameInput;
        private CharacterController _characterController;
        private bool _isEnabled;

        [Inject]
        private void Construct(GameInput gameInput)
            => _gameInput = gameInput;

        private void Update()
        {
            if (_isEnabled && _gameInput.CanMovement)
                _characterController.Move(_gameInput.GetDirectionMovememt() * _speed * Time.deltaTime);
        }

        public void Initialize()
            => _characterController = GetComponent<CharacterController>();

        public void ReactBallBurster(Ball ball)
            => BurstedBall?.Invoke(ball);

        public void Enable()
            => _isEnabled = true;

        public void Disable()
            => _isEnabled = false;
    }
}