using Common;
using Service;
using Service.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installer
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private ShipSpawnPoints _shipSpawnPoints;
        [SerializeField] private SceneContext _sceneContext;
        
        public override void InstallBindings()
        {
            InitGameStateFactory();
            BindShipSpawner();
        }

        private void InitGameStateFactory()
        {
            Container
                .Resolve<GameStateFactory>()
                .InitSceneContext(_sceneContext);
        }

        private void BindShipSpawner()
        {
            var shipSpawner = new ShipSpawner(Container.Resolve<BattleSetupHolder>(), _shipSpawnPoints);
            
            _shipSpawnPoints.Initialize();

            Container
                .Bind<ShipSpawner>()
                .FromInstance(shipSpawner)
                .AsSingle();
        }
    }
}