using Scripts.Players;
using Scripts.UI;
using Scripts.Zenject.Signals;
using Zenject;

namespace Scripts.StateMachine.States.SceneState
{
    public class GameplaySceneState : SceneState
    {
        private WinningPanel _winningPanel;
        private DefeatPanel _defeatPanel;
        private SignalBus _signalBus;
        private Player _player;

        public GameplaySceneState(SceneStateMachine stateMachine, Player player, WinningPanel winningPanel, DefeatPanel defeatPanel, SignalBus signalBus)
            : base(stateMachine)
        {
            _player = player;
            _signalBus = signalBus;
        }

        public override void Enter()
        {
            base.Enter();

            _player.Enable();
            Subscribe();
        }

        public override void Exit()
        {
            base.Exit();

            _player.Disable();
            Unsubscribe();
        }

        private void Subscribe() => _signalBus.Subscribe<FinishedGameSignal>(OnFinishedGameSignal);
        
        private void Unsubscribe() => _signalBus.Unsubscribe<FinishedGameSignal>(OnFinishedGameSignal);

        private void OnFinishedGameSignal(FinishedGameSignal signal) 
            => StateMachine.SwitchState<FinishedSceneState>();
    }
}