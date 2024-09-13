using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Interfaces;
using Scripts.Players;
using Scripts.SceneLoaders;
using Scripts.Spawner;
using Scripts.Zenject.Signals;
using System;
using Zenject;

namespace Scripts.StateMachine.States.SceneState
{
    public class BootstrapSceneState : SceneState
    {
        private Level _level;
        private BallSpawner _ballSpawner;
        private PlayerFactory _playerFactory;
        private VictoryConditionFactory _victoryConditionFactory;
        private LevelLoadingData _levelLoadingData;
        private SpawnPoint _spawnPoint;
        private SignalBus _signalBus;

        public BootstrapSceneState(SceneStateMachine stateMachine, ISaverData saverData, BallSpawner ballSPawner, Level level, 
            VictoryConditionFactory victoryConditionFactory, PlayerFactory playerFactory, LevelLoadingData levelLoadingData, SpawnPoint spawnPoint,
            SignalBus signalBus) 
            : base(stateMachine, saverData)
        {
            _level = level;
            _ballSpawner = ballSPawner;
            _playerFactory = playerFactory;
            _levelLoadingData = levelLoadingData;
            _victoryConditionFactory = victoryConditionFactory;
            _spawnPoint = spawnPoint;
            _signalBus = signalBus;
        }

        public override void Enter()
        {
            base.Enter();
            Data.SetPlayer(_playerFactory.Create(_spawnPoint));
            _signalBus.Fire(new SpawnTargetCameraSignal(Data.Player.transform));

            if(_ballSpawner.TrySpawn(out BallsController ballsController))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, ballsController, Data.Player));

            else
                throw new ArgumentException("Не могу запустить проект");

            StateMachine.SwitchState<GameplaySceneState>();
        }
    }
}