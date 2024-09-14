using Scripts.Configs;
using Scripts.Factory;
using UnityEngine;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayFactoryInstaller : MonoInstaller
    {
        [SerializeField] private BallConfiguration _ballConfiguration;

        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VictoryConditionFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BallConfiguration>().FromInstance(_ballConfiguration);
        }
    }
}