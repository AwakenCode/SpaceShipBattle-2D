using Infrastructure.State.StateMachine;
using Service;
using Service.Asset;
using Service.Data;
using Service.Factory;
using Service.Input;
using Zenject;

namespace Infrastructure.Installer
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindGameStateFactory();
            BindInput();
            BindDataProvider();
            BindAssetProvider();
            BindUIFactory();
            BindSceneLoader();
            BindCurtain();
            BindBattleSetupHolder();
        }

        private void BindGameStateFactory()
        {
            Container
                .Bind<GameStateFactory>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<UIFactory>()
                .AsSingle();
        }

        private void BindInput()
        {
            Container
                .Bind<IInputService>()
                .To<PlayerInput>()
                .AsSingle();
        }

        private void BindCurtain()
        {
            Container
                .Bind<Curtain>()
                .AsSingle();
        }

        private void BindDataProvider()
        {
            Container
                .Bind<IDataProvider>()
                .To<DataProvider>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
        }
        
        private void BindBattleSetupHolder()
        {
            Container
                .Bind<BattleSetupHolder>()
                .AsSingle();
        }
    }
}