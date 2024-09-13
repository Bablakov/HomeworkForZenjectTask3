using Scripts.Configs;
using Scripts.Controllers;
using Scripts.Factory;
using Scripts.Input;
using Scripts.Mediators;
using Scripts.Players;
using Scripts.Spawner;
using Scripts.UI;
using System.Collections.Generic;
using UnityEngine;
using Scripts.StateMachine.Installer;
using Zenject;
using static System.Collections.Specialized.BitVector32;
using Scripts.Zenject.Signals;

namespace Scripts.Zenject
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private BallConfiguration _ballConfiguration;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private Player _player;
        [SerializeField] private WinningPanel _winningPanel;
        [SerializeField] private DefeatPanel _defeatPanel;

        private Interfaces.IVictoryCondition _victoryCondition;
        private BallFactory _ballFactory;
        private BallSpawner _ballSpawner;
        private Level _level;
        private GameInput _gameInput;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<WinningPanel>().FromInstance(_winningPanel);
            Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel);
            Container.BindInterfacesAndSelfTo<BallConfiguration>().FromInstance(_ballConfiguration);
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player);
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VictoryConditionFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle().WithArguments(_spawnPoints);

            SceneStateMachineInstaller.Install(Container);
            Container.DeclareSignal<FinishedGameSignal>().OptionalSubscriber();
            Container.DeclareSignal<RestartedGameSignal>().OptionalSubscriber();
        }
    }
}