using Scripts.Controllers;
using Scripts.Input;
using Scripts.Spawner;
using Scripts.StateMachine;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayControllerInstaller : MonoInstaller
    {
        [SerializeField] private List<SpawnPointWithControllBall> _spawnPoints;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameMouseHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle().WithArguments(_spawnPoints);
            Container.Bind<SceneStateMachine>().AsSingle();
        }
    }
}