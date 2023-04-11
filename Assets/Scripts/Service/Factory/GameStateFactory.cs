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
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly SceneLoader _sceneLoader;
        private readonly Curtain _curtain;
        private readonly UIFactory _uiFactory;

        private SceneContext _activeSceneContext;

        public GameStateFactory(IDataProvider dataProvider, IAssetProvider assetProvider, SceneLoader sceneLoader, Curtain curtain, UIFactory uiFactory)
        {
            _dataProvider = dataProvider;
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _uiFactory = uiFactory;
        }

        public void InitSceneContext(SceneContext sceneContext) => 
            _activeSceneContext = sceneContext;

        public IState Create(Type type, GameStateMachine gameStateMachine)
        {
            IState state;
            if (type == typeof(BootstrapState))
                state = new BootstrapState(gameStateMachine, _assetProvider, _dataProvider, _curtain, _sceneLoader);
            else if (type == typeof(ShipSetupState))
                state = new ShipSetupState(gameStateMachine, _uiFactory, _curtain, _sceneLoader, _assetProvider,
                    _activeSceneContext.Container.Resolve<ShipFactory>());
            else if (type == typeof(BattleState))
                state = new BattleState(_curtain, _uiFactory, _activeSceneContext.Container.Resolve<ShipSpawner>());
            else
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
            
            return state;
        }
    }
}