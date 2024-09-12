using Scripts.Configs;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Input;
using Scripts.Interfaces;
using Scripts.Players;
using Scripts.Spawner;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Zenject
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BallConfiguration _ballConfiguration;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private Player _player;

        private Interfaces.IVictoryCondition _victoryCondition;
        private BallFactory _ballFactory;
        private BallSpawner _ballSpawner;
        private Level _level;
        private GameInput _gameInput;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BallConfiguration>().FromInstance(_ballConfiguration);
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player);
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VictoryConditionFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle().WithArguments(_spawnPoints);
        }
    }
}