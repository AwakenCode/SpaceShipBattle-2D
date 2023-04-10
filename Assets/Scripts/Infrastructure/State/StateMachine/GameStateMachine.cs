using System;
using System.Collections.Generic;
using Service;
using Service.Asset;
using Service.Data;
using Service.Factory;

namespace Infrastructure.State.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly GameStateFactory _gameStateFactory;
        private readonly Dictionary<Type, IState> _states = new();

        private IState _activeState;

        // public GameStateMachine(GameStateFactory gameStateFactory, IAssetProvider assetProvider, IDataProvider dataProvider,
        //     Curtain curtain, UIFactory uiFactory)
        // {
        //     _states = new Dictionary<Type, IState>()
        //     {
        //         [typeof(BootstrapState)] = new BootstrapState(this, assetProvider, dataProvider, curtain, sceneLoader),
        //         [typeof(ShipSetupState)] = new ShipSetupState(this, uiFactory, curtain, sceneLoader, assetProvider),
        //         [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader), 
        //         [typeof(BattleState)] = new BattleState(curtain, uiFactory, )
        //     };
        // }

        public void AddState<TState>(IState state) where TState : IState
        {
            _states.Add(typeof(TState), state);
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