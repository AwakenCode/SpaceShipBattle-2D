using Common;
using Service;
using Service.Factory;
using Service.Pool;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installer
{
    public class SetupInstaller : MonoInstaller
    {
        [SerializeField] private AmmunitionContainer _ammunitionContainer;
        [SerializeField] private SceneContext _sceneContext;

        public override void InstallBindings()
        {
            InitGameStateFactory();
            AddDontDestroyObjects();
            BindShipFactory();
            BindWeaponFactory();
            BindPlasmaPool();
            BindBulletPool();
            BindAmmunitionFactory();
        }

        private void InitGameStateFactory()
        {
            Container
                .Resolve<GameStateFactory>()
                .InitSceneContext(_sceneContext);
        }

        private void BindShipFactory()
        {
            Container
                .Bind<ShipFactory>()
                .AsSingle();
        }

        private void BindWeaponFactory()
        {
            Container
                .Bind<WeaponFactory>()
                .AsSingle();
        }

        private void BindAmmunitionFactory()
        {
            Container
                .Bind<AmmunitionFactory>()
                .AsSingle();
        }

        private void BindPlasmaPool()
        {

            Container
                .Bind<PlasmaPool>()
                .FromInstance(new PlasmaPool(_ammunitionContainer.PlasmaPoolContainer))
                .AsSingle();
        }

        private void BindBulletPool()
        {
            Container
                .Bind<BulletPool>()
                .FromInstance(new BulletPool(_ammunitionContainer.BulletPoolContainer))
                .AsSingle();
        }

        private void AddDontDestroyObjects()
        {
            var sceneLoader = Container.Resolve<SceneLoader>();
            sceneLoader.AddDontDestroyObject(_ammunitionContainer.gameObject);
        }
    }
}