using Common;
using Infrastructure.State.StateMachine;
using Service;
using Service.Asset;
using Service.Factory;

namespace Infrastructure.State
{
    public class ShipSetupState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly UIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly ShipFactory _shipFactory;
        private readonly GameStateFactory _gameStateFactory;
        private readonly Curtain _curtain; 
        
        public ShipSetupState(IGameStateMachine gameStateMachine, UIFactory uiFactory, Curtain curtain, SceneLoader sceneLoader,
            IAssetProvider assetProvider, ShipFactory shipFactory, GameStateFactory gameStateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _shipFactory = shipFactory;
            _gameStateFactory = gameStateFactory;
        }

        public void Enter()
        {
            PrepareScene();
            _curtain.Hide();
        }
        
        private void PrepareScene()
        {
            var setupWindow = _uiFactory.CreateShipSetupWindow();
            _sceneLoader.RemoveDontDestroyObject(setupWindow.gameObject);
            setupWindow.Initialize(_shipFactory);
            setupWindow.StartButtonClicked += TurnNextState;
        } 
        
        private async void TurnNextState()
        {
            _curtain.Show();
            await _assetProvider.PrepareFor(Constants.BattleSceneName);
            _sceneLoader.LoadSceneAsync(Constants.BattleSceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            var state = _gameStateFactory.Create(GameStateType.Battle);
            _gameStateMachine.AddState<BattleState>(state);
            _gameStateMachine.Enter<BattleState>();
        }
    }
}