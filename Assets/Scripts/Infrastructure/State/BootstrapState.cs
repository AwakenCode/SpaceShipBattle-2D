using System.Threading.Tasks;
using Common;
using Infrastructure.State.StateMachine;
using Service;
using Service.Asset;
using Service.Data;

namespace Infrastructure.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly Curtain _curtain;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider, IDataProvider dataProvider,
            Curtain curtain, SceneLoader sceneLoader)
        {
            _assetProvider = assetProvider;
            _dataProvider = dataProvider;
            _curtain = curtain;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await PrepareServices();
            _sceneLoader.LoadSceneAsync(Constants.ShipSetupSceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter<ShipSetupState>();
        }

        private async Task PrepareServices()
        {
            _dataProvider.Load();
            _assetProvider.Initialize();
            await _curtain.Initialize();
            _curtain.Show();
            await _assetProvider.PrepareFor(Constants.ShipSetupSceneName);
        }
    }
}