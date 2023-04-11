using Infrastructure.State;
using Infrastructure.State.StateMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure.Boot
{
    public class GameBootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Awake()
        {
            _gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}