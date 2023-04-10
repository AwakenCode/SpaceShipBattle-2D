using System.Collections.Generic;
using Service.Factory;
using Ship.Equipment.Weapon;
using UnityEngine;
using Zenject;

namespace Ship
{
    public class ShipGuns : MonoBehaviour
    {
        [field: SerializeField] public List<Transform> Slots { get; private set; }
        
        private WeaponFactory _weaponFactory;

        public Dictionary<int, Gun> Guns { get; } = new();

        [Inject]
        private void Construct(WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        private void Update()
        {
            Fire();
        }

        public void SetWeapon(WeaponType weaponType, int slotIndex)
        {
            if (Guns.ContainsKey(slotIndex))
            {
                if (Guns[slotIndex] != null)
                   Destroy(Guns[slotIndex].gameObject);
            }
         
            var gun = _weaponFactory.CreateWeapon(weaponType, Slots[slotIndex]);

            if (Guns.ContainsKey(slotIndex))
                Guns[slotIndex] = gun;
            else
                Guns.Add(slotIndex, gun);
        }
        
        private void Fire()
        {
            foreach (var gun in Guns.Values) 
                gun.Fire();
        }
    }
}