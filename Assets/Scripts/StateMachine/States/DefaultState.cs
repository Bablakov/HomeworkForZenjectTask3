using Scripts.Interfaces.StateMachine;
using System;
using UnityEngine;

namespace Scripts.StateMachine.States
{
    public abstract class DefaultState : IState
    {
        private Type _stateType;

        public DefaultState(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            _stateType = GetType();
        }

        protected IStateMachine StateMachine { get; }

        public virtual void Enter()
        {
            Debug.Log($"Enter {_stateType} state");
        }

        public virtual void Exit()
        {
            Debug.Log($"Exit {_stateType} state");
        }
    }
}