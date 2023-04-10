using System.Collections.Generic;
using Data.Ship;
using Service;
using Service.Data;
using Service.Factory;
using Ship;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ShipSelectPanel : MonoBehaviour
    {
        private readonly Dictionary<ShipType, Ship.Ship> _ships = new();
        
        [SerializeField] private Button _nextShip;
        [SerializeField] private Button _prevShip;
        [SerializeField] private Image _shipIcon;
        [SerializeField] private ShipSetupPanel _shipSetupPanel;
        [SerializeField] private WeaponSelectPanel _weaponSelectPanel;
        
        private ShipData[] _shipsData;
        private int _currentShipIndex;
        private BattleSetupHolder _battleSetupHolder;
        private SceneLoader _sceneLoader;
        private ShipFactory _shipFactory;

        public Ship.Ship CurrentShip { get; private set; }

        [Inject]
        private void Construct(IDataProvider dataProvider, BattleSetupHolder battleSetupHolder,
            SceneLoader sceneLoader)
        {
            _shipsData = dataProvider.GetAllShipData();
            _battleSetupHolder = battleSetupHolder;
            _sceneLoader = sceneLoader;
        }

        public void Initialize(ShipFactory shipFactory)
        {
            _shipFactory = shipFactory;
            
            PrepareCandidatesShips();
            SetShip(0);
            
            _nextShip.onClick.AddListener(OnNextButtonClicked);
            _prevShip.onClick.AddListener(OnPrevButtonClicked);
        }

        private void PrepareCandidatesShips()
        {
            foreach (var shipData in _shipsData)
            {
                var ship = _shipFactory.Create(shipData.Type);

                ship.Init(shipData);
                ship.gameObject.SetActive(false);
                _ships.Add(shipData.Type, ship);
                _sceneLoader.RemoveDontDestroyObject(ship.gameObject);
            }
        }

        private void OnPrevButtonClicked() => 
            SetShip(_currentShipIndex == 0 ? _shipsData.Length - 1 : _currentShipIndex - 1);

        private void OnNextButtonClicked() => 
            SetShip(_currentShipIndex == _shipsData.Length - 1 ? 0 : _currentShipIndex + 1);

        private void SetShip(int index)
        {
            if(CurrentShip)
                 _sceneLoader.RemoveDontDestroyObject(CurrentShip.gameObject);
            
            _currentShipIndex = index;
            var shipData = _shipsData[_currentShipIndex];
            _shipIcon.sprite = shipData.Icon;
            CurrentShip = _ships[shipData.Type];
            
            _shipSetupPanel.SetWeaponSlots(CurrentShip.ShipGuns);
            _weaponSelectPanel.ChangeCandidateShip(_shipSetupPanel.CandidateId, CurrentShip);
            _battleSetupHolder.SetShip(_shipSetupPanel.CandidateId, CurrentShip);
            _sceneLoader.AddDontDestroyObject(CurrentShip.gameObject);
        }
    }
}