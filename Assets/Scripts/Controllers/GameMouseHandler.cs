using Scripts.Input;
using Scripts.Interfaces;
using System;
using UnityEngine;

namespace Scripts.Controllers
{
    public class GameMouseHandler : IDisposable
    {
        private GameInput _gameInput;

        public GameMouseHandler(GameInput gameInput)
        {
            _gameInput = gameInput;
            Subscribe();
        }
        
        public void Dispose() => Unsubscribe();

        private void Subscribe()
            => _gameInput.MouseClicked += OnMouseClicked;

        private void Unsubscribe()
            => _gameInput.MouseClicked -= OnMouseClicked;

        private void OnMouseClicked(Vector2 mouseClickedPosition)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseClickedPosition);

            if(Physics.Raycast(ray, out hit))
                if (hit.transform.TryGetComponent(out IClicked clicked))
                    clicked.ClickInteract();
        }
    }
}