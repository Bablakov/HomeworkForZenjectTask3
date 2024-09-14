using Scripts.Input;
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
        private GameInput _gameInput;

        public GameplaySceneState(SceneStateMachine stateMachine, GameInput gameInput,
            WinningPanel winningPanel, DefeatPanel defeatPanel, SignalBus signalBus)
            : base(stateMachine)
        {
            _signalBus = signalBus;
            _gameInput = gameInput;
        }

        public override void Enter()
        {
            base.Enter();

            _gameInput.Enable();
            
            Subscribe();
        }

        public override void Exit()
        {
            base.Exit();

            Unsubscribe();
        }

        private void Subscribe() => _signalBus.Subscribe<FinishedGameSignal>(OnFinishedGameSignal);
        
        private void Unsubscribe() => _signalBus.Unsubscribe<FinishedGameSignal>(OnFinishedGameSignal);

        private void OnFinishedGameSignal(FinishedGameSignal signal) 
            => StateMachine.SwitchState<FinishedSceneState>();
    }
}