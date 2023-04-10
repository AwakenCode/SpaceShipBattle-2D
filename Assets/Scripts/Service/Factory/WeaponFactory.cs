using System;
using Data.Weapon;
using Service.Asset;
using Service.Data;
using Ship.Equipment.Weapon;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class WeaponFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public WeaponFactory(IDataProvider dataProvider, IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _dataProvider = dataProvider;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public Gun CreateWeapon(WeaponType weaponType, Transform parent = null)
        {
            return weaponType switch
            {
                WeaponType.BulletGun => CreateWeapon(_dataProvider.GetWeaponData(WeaponType.BulletGun), parent),
                WeaponType.PlasmaGun => CreateWeapon(_dataProvider.GetWeaponData(WeaponType.PlasmaGun), parent),
                WeaponType.LaserGun => CreateWeapon(_dataProvider.GetWeaponData(WeaponType.LaserGun), parent),
                WeaponType.MissileGun => CreateWeapon(_dataProvider.GetWeaponData(WeaponType.MissileGun), parent),
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null)
            };
        }

        private Gun CreateWeapon(WeaponData data, Transform parent)
        {
            var template = _assetProvider.Load(data.Template);
            var gun = _instantiator
                .InstantiatePrefab(template, parent.position, parent.rotation, parent)
                .GetComponent<Gun>();

            gun.Init(data);
            return gun;
        }
    }
}