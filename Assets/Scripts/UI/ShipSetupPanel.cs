using System.Collections.Generic;
using Data.Weapon;
using Service.Data;
using Service.Factory;
using Ship;
using Ship.Equipment.Weapon;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ShipSetupPanel : MonoBehaviour
    {
        private readonly Dictionary<WeaponType, WeaponData> _weaponsData = new();
        
        [SerializeField] private WeaponSelectPanel _weaponSelectPanel;
        [SerializeField] private Transform _modulesContent;
        [SerializeField] private Transform _weaponsContent;
        [field: SerializeField] public ShipSelectPanel ShipSelectPanel { get; private set; }
        [field: SerializeField] public CandidateId CandidateId { get; private set; }

        private UIFactory _uiFactory;

        [Inject]
        private void Construct(IDataProvider dataProvider, UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            
            foreach (var weaponData in dataProvider.GetAllWeaponData()) 
                _weaponsData.Add(weaponData.Type, weaponData);
        }

        public void Initialize(ShipFactory shipFactory)
        {
            ShipSelectPanel.Initialize(shipFactory);
        }
        
        public void ChangeWeaponSlot(WeaponType type, int slotIndex)
        {
            var slot = _weaponsContent.GetChild(slotIndex).GetComponent<Slot>();
            slot.SetIcon(_weaponsData[type].Icon);
        }

        public void SetWeaponSlots(ShipGuns shipGuns)
        {
            CleanEquipmentSlots();
            
            if(shipGuns.Slots.Count == 0) return;
            if (shipGuns.Guns.Count == 0)
            {
                SetEquipmentSlots(shipGuns.Slots.Count);
                return;
            } 

            foreach ((int index, var gun) in shipGuns.Guns)
            {
                var slot = _uiFactory.CreateWeaponSlot(gun.Data.Type, _weaponsContent.transform, index);
                slot.SelectButton.onClick.AddListener(() => OnSlotClicked(slot));
            }
        }

        private void SetEquipmentSlots(int weaponCount)
        {
            CleanEquipmentSlots();

            for (var i = 0; i < weaponCount; i++)
            {
                var slot = _uiFactory.CreateSlot(_weaponsContent.transform, i);
                slot.SelectButton.onClick.AddListener(() => OnSlotClicked(slot));
            }
        }

        private void OnSlotClicked(Slot slot) => 
            _weaponSelectPanel.Show(slot.Index, slot.Anchor, CandidateId);

        private void CleanEquipmentSlots()
        {
            for (var i = 0; i < _weaponsContent.childCount; i++) 
                Destroy(_weaponsContent.GetChild(i).gameObject);

            for (var i = 0; i < _modulesContent.childCount; i++) 
                Destroy(_modulesContent.GetChild(i).gameObject);
        }
    }
}