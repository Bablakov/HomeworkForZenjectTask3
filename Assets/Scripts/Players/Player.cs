using Scripts.Input;
using System;
using Scripts.Balls;
using Scripts.Interfaces;
using UnityEngine;
using Scripts.Configs;
using Zenject;

namespace Scripts.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, IBallBurster, ISpawning
    {
        public event Action<Ball> BurstedBall;

        private PlayerSpecificationsConfig _playerSpecificationsConfig;
        private GameInput _gameInput;
        private CharacterController _characterController;
        private bool _isEnabled;
        private Vector3 _startPosition;
        private Quaternion _startRotation;

        private float Speed => _playerSpecificationsConfig.Speed;

        private void Update()
        {
            if (_isEnabled && _gameInput.CanMovement)
                _characterController.Move(_gameInput.GetDirectionMovememt() * Speed * Time.deltaTime);
        }

        [Inject]
        public void Construct(GameInput gameInput, PlayerSpecificationsConfig playerConfig)
        {
            _gameInput = gameInput;
            _playerSpecificationsConfig = playerConfig;
        }

        public void Initialize()
            => _characterController = GetComponent<CharacterController>();

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = _startPosition = position;
            transform.rotation = _startRotation = rotation;
        }

        public void ResetTransform()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotation;
        }

        public void ReactBallBurster(Ball ball)
            => BurstedBall?.Invoke(ball);

        public void Enable()
            => _isEnabled = true;

        public void Disable()
            => _isEnabled = false;
    }
}