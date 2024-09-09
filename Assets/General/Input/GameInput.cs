using UnityEngine;

namespace General.Input
{
    public class GameInput
    {
        private GameInputAction _inputAction;
        public GameInput() 
        {
            _inputAction = new GameInputAction();
            _inputAction.Player.Enable();
        }

        public bool CanMovement => _inputAction.Player.Movement.ReadValue<Vector2>() != Vector2.zero;

        public Vector3 GetDirectionMovememt()
        {
            var directionInput = _inputAction.Player.Movement.ReadValue<Vector2>();
            var directionMovement = new Vector3(directionInput.x, 0, directionInput.y);
            return directionMovement;
        }
    }
}