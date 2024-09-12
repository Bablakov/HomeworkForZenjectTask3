namespace Scripts.Interfaces.StateMachine
{
    public interface IStateMachine
    {
        public void SwitchState<TState>() where TState : class, IState;

        public void RegisterState<TState>(TState state) where TState : class, IExitableState;
    }
}