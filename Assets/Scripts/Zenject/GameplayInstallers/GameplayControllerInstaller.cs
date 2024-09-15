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
            BindGameInput();
            BindGameMouseHandler();
            BindBallSpawner();
            BindSceneStateMachine();
        }

        private void BindGameInput() 
            => Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();

        private void BindGameMouseHandler() 
            => Container.BindInterfacesAndSelfTo<GameMouseHandler>().AsSingle();

        private void BindBallSpawner() 
            => Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle().WithArguments(_spawnPoints);

        private void BindSceneStateMachine() 
            => Container.Bind<SceneStateMachine>().AsSingle();
    }
}