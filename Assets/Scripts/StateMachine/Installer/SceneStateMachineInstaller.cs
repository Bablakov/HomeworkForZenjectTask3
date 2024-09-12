using Scripts.Factory;
using Zenject;

namespace Scripts.StateMachine.Installer
{
    public class SceneStateMachineInstaller : Installer<SceneStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<SceneStateMachine>().AsSingle();
        }
    }
}
