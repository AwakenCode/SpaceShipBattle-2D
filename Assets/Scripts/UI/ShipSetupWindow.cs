using System;
using System.Collections.Generic;
using Service.Factory;
using Ship;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShipSetupWindow : MonoBehaviour
    {
        [SerializeField] private WeaponSelectPanel _weaponSelectPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _hideAllButton;
        [SerializeField] private ShipSetupPanel[] _shipPanels;

        public Dictionary<CandidateId, ShipSetupPanel> ShipSetupPanels { get; } = new();
        
        public event Action StartButtonClicked;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(() => StartButtonClicked?.Invoke());
            _hideAllButton.onClick.AddListener(HideAllSelectPanels);
        }

        private void HideAllSelectPanels() => _weaponSelectPanel.Hide();

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _hideAllButton.onClick.RemoveAllListeners();
        }

        public void Initialize(ShipFactory shipFactory)
        {
            _weaponSelectPanel.Initialize();

            foreach (var shipPanel in _shipPanels)
            {
                shipPanel.Initialize(shipFactory);
                ShipSetupPanels.Add(shipPanel.CandidateId, shipPanel);
            }

            _weaponSelectPanel.Hide();
        }
    }
}