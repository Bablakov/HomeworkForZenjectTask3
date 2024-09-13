using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Players;
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
        private Player _player; 

        public RestartSceneState(SceneStateMachine stateMachine, BallSpawner ballSPawner, Level level, VictoryConditionFactory victoryConditionFactory, 
            Player player, LevelLoadingData levelLoadingData)
            : base(stateMachine)
        {
            _level = level;
            _player = player;
            _ballSpawner = ballSPawner;
            _levelLoadingData = levelLoadingData;
            _victoryConditionFactory = victoryConditionFactory;
        }

        public override void Enter()
        {
            base.Enter();
            _player.ResetTransform();

            if(_ballSpawner.TrySpawn(out BallsController ballsController))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, ballsController, _player));

            else
                throw new ArgumentException("Не могу запустить проект");

            StateMachine.SwitchState<GameplaySceneState>();
        }
    }
}