using Scripts.SceneLoaderImport.Loader;
using Zenject;

namespace Scripts.Installer
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
            => BindLoader();

        private void BindLoader()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.Bind<SceneLoadMediator>().AsSingle();
        }
    }
}