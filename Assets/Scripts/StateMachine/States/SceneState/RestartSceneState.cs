using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Interfaces;
using Scripts.SceneLoaders;
using Scripts.Spawner;
using System;

namespace Scripts.StateMachine.States.SceneState
{
    public class RestartSceneState : SceneState
    {
        private Level _level;
        private BallSpawner _ballSpawner;
        private VictoryConditionFactory _victoryConditionFactory;
        private LevelLoadingData _levelLoadingData;

        public RestartSceneState(SceneStateMachine stateMachine, ISaverData saverData, 
            BallSpawner ballSPawner, Level level, VictoryConditionFactory victoryConditionFactory,
            LevelLoadingData levelLoadingData)
            : base(stateMachine, saverData)
        {
            _level = level;
            _ballSpawner = ballSPawner;
            _levelLoadingData = levelLoadingData;
            _victoryConditionFactory = victoryConditionFactory;
        }

        public override void Enter()
        {
            base.Enter();
            Data.Player.ResetTransform();

            if(_ballSpawner.TrySpawn(out BallsController ballsController))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, ballsController, Data.Player));

            else
                throw new ArgumentException("Не могу запустить проект");

            StateMachine.SwitchState<GameplaySceneState>();
        }
    }
}