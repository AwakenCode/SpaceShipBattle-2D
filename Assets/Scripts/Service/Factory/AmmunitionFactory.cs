using System;
using Data.Ammunition;
using Service.Asset;
using Service.Data;
using Service.Pool;
using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class AmmunitionFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly BulletPool _bulletPool;
        private readonly PlasmaPool _plasmaPool;

        public AmmunitionFactory(IDataProvider dataProvider, IAssetProvider assetProvider, IInstantiator instantiator,
            BulletPool bulletPool, PlasmaPool plasmaPool)
        {
            _dataProvider = dataProvider;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _bulletPool = bulletPool;
            _plasmaPool = plasmaPool;
        }
        
        public GameObject Create(AmmunitionType type, Transform parent)
        {
            return type switch
            {
                AmmunitionType.Bullet => CreateBullet(parent),
                AmmunitionType.Laser => CreateLaser(),
                AmmunitionType.Missile => CreateMissile(),
                AmmunitionType.Plasma => CreatePlasma(parent),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private GameObject CreatePlasma(Transform parent)
        {
            if (_plasmaPool.InactiveCount > 0)
                return _plasmaPool.Get().gameObject;

            var data = _dataProvider.GetAmmunitionData(AmmunitionType.Plasma);
            var plasma = CreateAmmunition(data, parent).GetComponent<Plasma>();
            plasma.Destroyed += _plasmaPool.Release;
            
            return plasma.gameObject;
        }

        private GameObject CreateMissile()
        {
            throw new NotImplementedException();
        }

        private GameObject CreateLaser()
        {
            throw new NotImplementedException();
        }

        private GameObject CreateBullet(Transform parent)
        {
            if (_bulletPool.InactiveCount > 0)
                return _bulletPool.Get().gameObject;

            var data = _dataProvider.GetAmmunitionData(AmmunitionType.Bullet);
            var bullet = CreateAmmunition(data, parent).GetComponent<Bullet>();
            bullet.Destroyed += _bulletPool.Release;
            
            return bullet.gameObject;
        }

        private GameObject CreateAmmunition(AmmunitionData data, Transform parent)
        {
            var template = _assetProvider.Load(data.Template);
            return _instantiator
                .InstantiatePrefab(template, parent.position, parent.rotation, parent);
        }
    }
}