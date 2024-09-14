using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Input
{
    public class GameInput : IDisposable
    {
        public event Action<Vector2> MouseClicked;

        private GameInputAction _inputAction;

        public GameInput() 
        {
            _inputAction = new GameInputAction();
            Subscribe();
        }

        public void Dispose()
            => Unsubscribe();

        public void Enable()
            => _inputAction.Player.Enable();

        public void Disable()
            => _inputAction.Player.Disable();

        private void Subscribe()
            => _inputAction.Player.Click.performed += OnClick;

        private void Unsubscribe()
            => _inputAction.Player.Click.performed -= OnClick;

        private void OnClick(InputAction.CallbackContext context)
            => MouseClicked?.Invoke(Mouse.current.position.ReadValue());
    }
}