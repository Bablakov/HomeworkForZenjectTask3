using Scripts.SceneLoaderImport.Loader;
using Scripts.SceneLoaders;
using Zenject;

namespace Scripts.Zenject
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