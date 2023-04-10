using System.Collections.Generic;
using System.Linq;
using Common;
using Data.Ammunition;
using Data.Scene;
using Data.Ship;
using Data.UI;
using Data.Weapon;
using Ship;
using Ship.Equipment.Weapon;
using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;

namespace Service.Data
{
    public class DataProvider : IDataProvider
    {
        private Dictionary<ShipType, ShipData> _shipData;
        private Dictionary<WeaponType, WeaponData> _weaponData;
        private Dictionary<AmmunitionType, AmmunitionData> _ammunitionData;
        private SceneData _sceneData;
        private UIData _uiData;

        public void Load()
        {
            _sceneData = Resources.Load<SceneData>(Constants.SceneDataPath);
            _uiData = Resources.Load<UIData>(Constants.UIDataPath);
            
            _shipData = Resources
                .LoadAll<ShipData>(Constants.ShipDataPath)
                .ToDictionary(data => data.Type, data => data);

            _weaponData = Resources
                .LoadAll<WeaponData>(Constants.WeaponDataPath)
                .ToDictionary(data => data.Type, data => data);

            _ammunitionData = Resources
                .LoadAll<AmmunitionData>(Constants.AmmunitionDataPath)
                .ToDictionary(data => data.Type, data => data);
        }

        public ShipData GetShipData(ShipType type) => 
            _shipData.TryGetValue(type, out var data) ? data : null;

        public WeaponData GetWeaponData(WeaponType type) => 
            _weaponData.TryGetValue(type, out var data) ? data : null;

        public AmmunitionData GetAmmunitionData(AmmunitionType type) => 
            _ammunitionData.TryGetValue(type, out var data) ? data : null;

        public SceneData GetSceneData() => _sceneData;

        public UIData GetUIData() => _uiData;

        public ShipData[] GetAllShipData() => _shipData.Values.ToArray();

        public WeaponData[] GetAllWeaponData() => _weaponData.Values.ToArray();

        public AmmunitionData[] GetAllAmmunitionData() => _ammunitionData.Values.ToArray();
    }
}