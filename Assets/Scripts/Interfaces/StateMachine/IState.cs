namespace Scripts.Interfaces.StateMachine
{
    public interface IState : IExitableState
    {
        public void Enter();
    }
}