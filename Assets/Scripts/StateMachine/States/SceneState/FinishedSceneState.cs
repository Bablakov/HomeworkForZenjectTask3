using Scripts.Interfaces;
using Scripts.Zenject.Signals;
using Zenject;

namespace Scripts.StateMachine.States.SceneState
{
    public class FinishedSceneState : SceneState
    {
        private SignalBus _signalBus;

        public FinishedSceneState(SceneStateMachine stateMachine, ISaverData saverData, SignalBus signalBus) 
            : base(stateMachine, saverData)
            => _signalBus = signalBus;
    
        public override void Enter()
        {
            base.Enter();

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
            => StateMachine.SwitchState<RestartSceneState>();
    }
}