using Scripts.Controllers;
using Scripts.Mediators;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLevel();
            BindLevelMediator();
        }

        private void BindLevel() 
            => Container.BindInterfacesAndSelfTo<Level>().AsSingle();

        private void BindLevelMediator() 
            => Container.BindInterfacesAndSelfTo<LevelMediator>().AsSingle();
    }
}