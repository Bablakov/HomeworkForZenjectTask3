using Scripts.Interfaces.StateMachine;
using System;
using System.Collections.Generic;

namespace Scripts.StateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new();
        private IExitableState _currentState;

        public void SwitchState<TState>() where TState : class, IState
        {
            TState nextState = GetNextStateWithSetCurrentState<TState>();
            nextState.Enter();
        }

        public void RegisterState<TState>(TState state) where TState : class, IExitableState
        {
            Type stateType = typeof(TState);

            if (_registeredStates.ContainsKey(stateType) == true)
                return;

            _registeredStates.Add(stateType, state);
        }

        private TState GetNextStateWithSetCurrentState<TState>() where TState : class, IExitableState
        {
            TState nextState = GetState<TState>();

            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            return nextState;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            Type stateType = typeof(TState);

            if (_registeredStates.ContainsKey(stateType) == false)
                throw new Exception($"The condition with type {stateType} is not registered");

            return _registeredStates[stateType] as TState;
        }
    }
}
