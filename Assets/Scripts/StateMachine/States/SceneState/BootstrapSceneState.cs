using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Players;
using Scripts.SceneLoaders;
using Scripts.Spawner;
using System;

namespace Scripts.StateMachine.States.SceneState
{
    public class BootstrapSceneState : SceneState
    {
        //[SerializeField] private Transform _spawnPointPlayer;
        private Level _level;
        private BallSpawner _ballSpawner;
        private PlayerFactory _playerFactory;
        private VictoryConditionFactory _victoryConditionFactory;
        private Player _player;
        private LevelLoadingData _levelLoadingData;

        public BootstrapSceneState(SceneStateMachine stateMachine, BallSpawner ballSPawner, Level level, VictoryConditionFactory victoryConditionFactory,
            PlayerFactory playerFactory, Player player, LevelLoadingData levelLoadingData) 
            : base(stateMachine)
        {
            _level = level;
            _player = player;
            _ballSpawner = ballSPawner;
            _playerFactory = playerFactory;
            _levelLoadingData = levelLoadingData;
            _victoryConditionFactory = victoryConditionFactory;
        }

        public override void Enter()
        {
            base.Enter();
            _player.Initialize();

            //_playerFactory.Create(_spawnPointPlayer.position, _spawnPointPlayer.rotation);  
            if(_ballSpawner.TrySpawn(out BallsController ballsController))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, ballsController, _player));

            else
                throw new ArgumentException("Не могу запустить проект");

            StateMachine.SwitchState<GameplaySceneState>();
        }
    }
}