using Scripts.Interfaces.StateMachine;
using Zenject;

namespace Scripts.Factory
{
    public class StatesFactory
    {
        private IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public TState Create<TState>() where TState : IExitableState =>
            _instantiator.Instantiate<TState>();
    }
}