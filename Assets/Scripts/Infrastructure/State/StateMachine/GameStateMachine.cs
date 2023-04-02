using System;
using System.Collections.Generic;

namespace Infrastructure.State.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(),
                [typeof(LoadLevelState)] = new LoadLevelState(), 
                [typeof(BattleState)] = new BattleState()
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        private IState ChangeState<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = GetState<TState>();
            return _activeState;
        }

        private IState GetState<TState>() where TState : IState => _states[typeof(TState)];
    }
}