using Scripts.Controllers;
using Scripts.Mediators;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelMediator>().AsSingle();
        }
    }
}