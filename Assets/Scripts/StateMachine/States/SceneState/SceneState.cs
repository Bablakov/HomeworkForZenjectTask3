using Scripts.Interfaces;

namespace Scripts.StateMachine.States.SceneState
{
    public abstract class SceneState : DefaultState
    {
        protected readonly ISaverData Data;

        public SceneState(SceneStateMachine stateMachine, ISaverData savaerData)
            : base(stateMachine)
            => Data = savaerData;
    }
}   