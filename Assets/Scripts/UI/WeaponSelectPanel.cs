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
    public class WeaponSelectPanel : EquipmentSelectPanel
    {
        private readonly Dictionary<CandidateId, Ship.Ship> _candidatesShip = new();

        [SerializeField] private RectTransform _content;
        [SerializeField] private ShipSetupWindow _shipSetupWindow;

        private CanvasGroup _canvasGroup;
        private UIFactory _uiFactory;
        private WeaponData[] _weapons; 

        [Inject]
        private void Construct(UIFactory uiFactory, IDataProvider dataProvider)
        {
            _uiFactory = uiFactory;
            _weapons = dataProvider.GetAllWeaponData();
        }

        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        public void Initialize()
        {
            for (var i = 0; i < _weapons.Length; i++)
            {
                var type = _weapons[i].Type;
                var slot = _uiFactory.CreateWeaponSlot(type, _content.transform, i);
                slot.SelectButton.onClick.AddListener(() => OnSlotClicked(type));
            }
        }

        public void ChangeCandidateShip(CandidateId candidateId, Ship.Ship ship) => 
            _candidatesShip[candidateId] = ship;

        private void OnSlotClicked(WeaponType type)
        {
            _candidatesShip[CandidateId].ShipGuns.SetWeapon(type, SlotIndex);
            _shipSetupWindow.ShipSetupPanels[CandidateId].ChangeWeaponSlot(type, SlotIndex);
            Hide();
        }
    }
}