using Scripts.Interfaces;
using Scripts.Players;

namespace Scripts.StateMachine.States.SceneState
{
    public class SceneStateMachineData : ISaverData
    {
        private Player _player;

        public Player Player => _player;

        public void SetPlayer(Player player) => _player = player;
    }
}