using UnityEngine;

namespace Ship.Weapon
{
    public abstract class Gun : MonoBehaviour, IWeapon
    {
        public void Fire()
        {
            throw new System.NotImplementedException();
        }
    }
}