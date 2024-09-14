using Assets.Scripts.Zenject.Signals;
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
            Container.DeclareSignal<FinishedGameSignal>().OptionalSubscriber();
            Container.DeclareSignal<RestartedGameSignal>().OptionalSubscriber();
            Container.DeclareSignal<ClickedOnBallSignal>().OptionalSubscriber();
        }
    }
}