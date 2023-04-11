using System;
using System.Collections.Generic;
using Service.Factory;

namespace Infrastructure.State.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly GameStateFactory _gameStateFactory;
        private readonly Dictionary<Type, IState> _states = new();

        private IState _activeState;

        public GameStateMachine(GameStateFactory gameStateFactory) => _gameStateFactory = gameStateFactory;

        public void Enter<TState>() where TState : IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        private void AddState<TState>(IState state) where TState : IState => 
            _states.Add(typeof(TState), state);

        private IState ChangeState<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = GetState<TState>();
            return _activeState;
        }

        private IState GetState<TState>() where TState : IState
        {
            if(_states.TryGetValue(typeof(TState), out var value))
                return value;
            
            var state = _gameStateFactory.Create(typeof(TState), this);
            AddState<TState>(state);

            return state;
        }
    }
}