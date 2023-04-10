using Infrastructure.State;
using Infrastructure.State.StateMachine;
using Service.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure.Boot
{
    public class GameBootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        private GameStateFactory _gameStateFactory;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, GameStateFactory gameStateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameStateFactory = gameStateFactory;
        }
        
        private void Awake()
        {
            var state = _gameStateFactory.Create(GameStateType.Bootstrap);
            _gameStateMachine.AddState<BootstrapState>(state);
            _gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}