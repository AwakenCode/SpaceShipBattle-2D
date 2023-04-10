using Data.Weapon;
using Service.Factory;
using UnityEngine;
using Zenject;

namespace Ship.Equipment.Weapon
{
    public abstract class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] protected Transform ShootPoint;
        
        public AmmunitionFactory AmmunitionFactory { get; private set; }
        public WeaponData Data { get; private set; }
        
        [Inject]
        private void Construct(AmmunitionFactory ammunitionFactory)
        {
            AmmunitionFactory = ammunitionFactory;
        }

        public void Init(WeaponData weaponData)
        {
            Data = weaponData;
        }
        
        public abstract void Fire();
    }
}