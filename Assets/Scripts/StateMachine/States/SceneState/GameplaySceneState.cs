using Scripts.Interfaces;
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

        public GameplaySceneState(SceneStateMachine stateMachine, ISaverData saverData, 
            WinningPanel winningPanel, DefeatPanel defeatPanel, SignalBus signalBus)
            : base(stateMachine, saverData)
            => _signalBus = signalBus;

        public override void Enter()
        {
            base.Enter();

            Data.Player.Enable();
            Subscribe();
        }

        public override void Exit()
        {
            base.Exit();

            Data.Player.Disable();
            Unsubscribe();
        }

        private void Subscribe() => _signalBus.Subscribe<FinishedGameSignal>(OnFinishedGameSignal);
        
        private void Unsubscribe() => _signalBus.Unsubscribe<FinishedGameSignal>(OnFinishedGameSignal);

        private void OnFinishedGameSignal(FinishedGameSignal signal) 
            => StateMachine.SwitchState<FinishedSceneState>();
    }
}