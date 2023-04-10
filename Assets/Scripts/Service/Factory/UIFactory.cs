using System.Threading.Tasks;
using Service.Asset;
using Service.Data;
using Ship.Equipment.Weapon;
using UI;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class UIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IDataProvider _dataProvider;

        public UIFactory(IAssetProvider assetProvider, IDataProvider dataProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _dataProvider = dataProvider;
            _instantiator = instantiator;
        }

        public async Task<CurtainUI> CreateCurtain()
        {
            var template = await _assetProvider.LoadAsync(_dataProvider.GetUIData().Curtain);
            return _instantiator
                .InstantiatePrefab(template)
                .GetComponent<CurtainUI>();
        }

        public ShipSetupWindow CreateShipSetupWindow()
        {
            var template = _assetProvider.Load(_dataProvider.GetUIData().ShipSetupWindow);
            return _instantiator
                .InstantiatePrefab(template)
                .GetComponent<ShipSetupWindow>();
        }

        public BattleWindow CreateBattleWindow()
        {
            var template = _assetProvider.Load(_dataProvider.GetUIData().BattleWindow);
            return _instantiator
                .InstantiatePrefab(template)
                .GetComponent<BattleWindow>();
        }
        
        public Slot CreateWeaponSlot(WeaponType type, Transform parent, int index)
        {
            var data = _dataProvider.GetWeaponData(type);
            var slot = CreateSlot(parent);
            
            slot.Init(index, data.Icon);
            return slot;
        }

        public Slot CreateSlot(Transform parent, int index)
        {
            var slot = CreateSlot(parent);

            slot.Init(index);
            return slot;
        }

        private Slot CreateSlot(Transform parent)
        {
            var template = _assetProvider.Load(_dataProvider.GetUIData().Slot);
            return _instantiator
                .InstantiatePrefab(template, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<Slot>();
        }
    }
}