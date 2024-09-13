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
using Scripts.Zenject.Signals;
using Scripts.Interfaces;
using Scripts.StateMachine.States.SceneState;

namespace Scripts.Zenject
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private BallConfiguration _ballConfiguration;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private List<SpawnPointWithControllObject> _spawnPoints;
        [SerializeField] private WinningPanel _winningPanel;
        [SerializeField] private DefeatPanel _defeatPanel;
        [SerializeField] private SpawnPoint _spawnPointPlayer;
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            SceneStateMachineData sceneStateMachineData = new SceneStateMachineData();

            Container.BindInterfacesAndSelfTo<ISaverData>().FromInstance(sceneStateMachineData);
            Container.BindInterfacesAndSelfTo<SpawnPoint>().FromInstance(_spawnPointPlayer);
            Container.BindInterfacesAndSelfTo<WinningPanel>().FromInstance(_winningPanel);
            Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel);
            Container.BindInterfacesAndSelfTo<BallConfiguration>().FromInstance(_ballConfiguration);
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VictoryConditionFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle().WithArguments(_spawnPoints);
            Container.BindInterfacesAndSelfTo<PlayerConfig>().FromInstance(_playerConfig);
            Container.BindInterfacesAndSelfTo<PlayerSpecificationsConfig>().FromInstance(_playerConfig.PlayerSpecificationsConfig);
            /*
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player);*/

            SceneStateMachineInstaller.Install(Container);
            Container.DeclareSignal<FinishedGameSignal>().OptionalSubscriber();
            Container.DeclareSignal<RestartedGameSignal>().OptionalSubscriber();
            Container.DeclareSignal<SpawnTargetCameraSignal>().OptionalSubscriber();
        }
    }
}