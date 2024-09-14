using Scripts.Input;
using Scripts.Zenject.Signals;
using Zenject;

namespace Scripts.StateMachine.States.SceneState
{
    public class FinishedSceneState : SceneState
    {
        private SignalBus _signalBus;
        private GameInput _gameInput;

        public FinishedSceneState(SceneStateMachine stateMachine, SignalBus signalBus, GameInput gameInput) 
            : base(stateMachine)
        {
            _signalBus = signalBus;
            _gameInput = gameInput;
        }
    
        public override void Enter()
        {
            base.Enter();

            _gameInput.Disable();

            Subscribe();
        }

        public override void Exit()
        {
            base.Exit();

            Unsubscribe();
        }

        private void Subscribe() => _signalBus.Subscribe<RestartedGameSignal>(OnFinishedGameSignal);

        private void Unsubscribe() => _signalBus.Unsubscribe<RestartedGameSignal>(OnFinishedGameSignal);

        private void OnFinishedGameSignal(RestartedGameSignal signal)
            => StateMachine.SwitchState<BootstrapSceneState>();
    }
}