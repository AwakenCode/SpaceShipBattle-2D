using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ship.Weapon
{
    public class ShipGuns : MonoBehaviour
    {
        private List<Gun> _guns;

        [Inject]
        private void Construct(List<Gun> guns)
        {
            _guns = guns;
        }
        
        private void Fire()
        {
            foreach (var gun in _guns) 
                gun.Fire();
        }
    }
}