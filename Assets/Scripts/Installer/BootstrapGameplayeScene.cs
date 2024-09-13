using Scripts.Factory;
using Scripts.StateMachine;
using Scripts.StateMachine.States.SceneState;
using UnityEngine;
using Zenject;

namespace Scripts.Installer
{
    public class BootstrapGameplayeScene : MonoBehaviour
    {
        private SceneStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        void Construct(SceneStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapSceneState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<FinishedSceneState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameplaySceneState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<RestartSceneState>());

            _gameStateMachine.SwitchState<BootstrapSceneState>();
        }
    }
}