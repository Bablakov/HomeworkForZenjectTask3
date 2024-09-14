using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.SceneLoaders;
using Scripts.Spawner;
using System;

namespace Scripts.StateMachine.States.SceneState
{
    public class BootstrapSceneState : SceneState
    {
        private Level _level;
        private BallSpawner _ballSpawner;
        private VictoryConditionFactory _victoryConditionFactory;
        private LevelLoadingData _levelLoadingData;

        public BootstrapSceneState(SceneStateMachine stateMachine, BallSpawner ballSPawner, Level level, 
            VictoryConditionFactory victoryConditionFactory, LevelLoadingData levelLoadingData) 
            : base(stateMachine)
        {
            _level = level;
            _ballSpawner = ballSPawner;
            _levelLoadingData = levelLoadingData;
            _victoryConditionFactory = victoryConditionFactory;
        }

        public override void Enter()
        {
            base.Enter();

            if(_ballSpawner.TrySpawn(out BallsController ballsController))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, ballsController));

            else
                throw new ArgumentException("Не могу запустить проект");

            StateMachine.SwitchState<GameplaySceneState>();
        }
    }
}