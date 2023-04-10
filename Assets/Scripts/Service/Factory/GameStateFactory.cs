using System;
using Infrastructure.State;
using Infrastructure.State.StateMachine;
using Service.Asset;
using Service.Data;
using Zenject;

namespace Service.Factory
{
    public class GameStateFactory
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly SceneLoader _sceneLoader;
        private readonly Curtain _curtain;
        private readonly UIFactory _uiFactory;
        
        private SceneContext _activeSceneContext;

        public GameStateFactory(IGameStateMachine gameStateMachine, IDataProvider dataProvider, IAssetProvider assetProvider, SceneLoader sceneLoader, Curtain curtain, UIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _dataProvider = dataProvider;
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _uiFactory = uiFactory;
        }

        public void InitSceneContext(SceneContext sceneContext) => 
            _activeSceneContext = sceneContext;

        public IState Create(GameStateType type)
        {
            return type switch
            {
                GameStateType.Bootstrap => new BootstrapState(_gameStateMachine, _assetProvider, _dataProvider, _curtain, _sceneLoader, this),
                GameStateType.ShipSetup => new ShipSetupState(_gameStateMachine, _uiFactory, _curtain, _sceneLoader, _assetProvider, _activeSceneContext.Container.Resolve<ShipFactory>(), this),
                GameStateType.Battle => new BattleState(_curtain, _uiFactory, _activeSceneContext.Container.Resolve<ShipSpawner>()),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}