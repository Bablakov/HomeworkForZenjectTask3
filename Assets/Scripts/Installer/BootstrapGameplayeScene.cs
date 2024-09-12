using Scripts.Balls;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Interfaces;
using Scripts.Players;
using Scripts.SceneLoaderImport.Loader;
using Scripts.Spawner;
using Scripts.VictoryCondition;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Installer
{
    public class BootstrapGameplayeScene : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPointPlayer;
        
        private Level _level;
        private BallSpawner _ballSpawner;
        private PlayerFactory _playerFactory;
        private VictoryConditionFactory _victoryConditionFactory;
        private Player _player;
        private LevelLoadingData _levelLoadingData;

        [Inject]
        private void Construct(BallSpawner ballSPawner, Level level, VictoryConditionFactory victoryConditionFactory, 
            PlayerFactory playerFactory, Player ballBurster, LevelLoadingData levelLoadingData)
        {
            _level = level;
            _ballSpawner = ballSPawner;
            _playerFactory = playerFactory;
            _victoryConditionFactory = victoryConditionFactory;
            _player = ballBurster;
            _levelLoadingData = levelLoadingData;
        }

        private void Awake()
        {
            _player.Initialize();
            _player.Enable();

            //_playerFactory.Create(_spawnPointPlayer.position, _spawnPointPlayer.rotation);  
            if (_ballSpawner.TrySpawn(out IEnumerable<Ball> balls))
                _level.SetVictoryCondition(_victoryConditionFactory.Create(_levelLoadingData.Level, new BallsController(balls), _player));

            else
                throw new ArgumentException("Не могу запустить проект");
        }
    }
}