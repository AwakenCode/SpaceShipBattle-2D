using System;
using Data.Ship;
using Service.Asset;
using Service.Data;
using Ship;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class ShipFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public ShipFactory(IDataProvider dataProvider, IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _dataProvider = dataProvider;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public Ship.Ship Create(ShipType shipType, Transform parent = null)
        {
            return shipType switch
            {
                ShipType.BSApocalypse => Create(_dataProvider.GetShipData(ShipType.BSApocalypse), parent),
                ShipType.CSGuardian => Create(_dataProvider.GetShipData(ShipType.CSGuardian), parent),
                ShipType.BCSolarLuisa => Create(_dataProvider.GetShipData(ShipType.BCSolarLuisa), parent),
                ShipType.HSConstantine =>  Create(_dataProvider.GetShipData(ShipType.HSConstantine), parent),
                ShipType.SSAvius => Create(_dataProvider.GetShipData(ShipType.SSAvius), parent),
                ShipType.HGPegasus => Create(_dataProvider.GetShipData(ShipType.HGPegasus), parent),
                _ => throw new ArgumentOutOfRangeException(nameof(shipType), shipType, null)
            };
        }

        private Ship.Ship Create(ShipData data, Transform parent)
        {
            var template = _assetProvider.Load(data.Template);
            return  _instantiator
                .InstantiatePrefab(template, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<Ship.Ship>();
        }
    }
}