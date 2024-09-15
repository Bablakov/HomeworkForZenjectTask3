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
            BindStatesFactory();
            BindVictoryConditionFactory();
            BindBallFactory();
            BindBallConfiguration();
        }

        private void BindStatesFactory() 
            => Container.Bind<StatesFactory>().AsSingle();

        private void BindVictoryConditionFactory() 
            => Container.BindInterfacesAndSelfTo<VictoryConditionFactory>().AsSingle();

        private void BindBallFactory() 
            => Container.BindInterfacesAndSelfTo<BallFactory>().AsSingle();

        private void BindBallConfiguration() 
            => Container.BindInterfacesAndSelfTo<BallConfiguration>().FromInstance(_ballConfiguration);
    }
}