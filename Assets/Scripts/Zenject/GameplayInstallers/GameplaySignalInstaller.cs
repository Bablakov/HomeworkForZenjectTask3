using Scripts.Zenject.Signals;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplaySignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignalBus();
            BindSignals();
        }

        private void BindSignalBus() 
            => SignalBusInstaller.Install(Container);

        private void BindSignals()
        {
            BindFinishedGameSignal();
            BindRestartedGameSignal();
        }

        private void BindFinishedGameSignal() 
            => Container.DeclareSignal<FinishedGameSignal>().OptionalSubscriber();

        private void BindRestartedGameSignal() 
            => Container.DeclareSignal<RestartedGameSignal>().OptionalSubscriber();
    }
}