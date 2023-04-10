using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;

namespace Ship.Equipment.Weapon
{
    public class BulletGun : Gun
    {
        private float _elapsedTime;
        private float _currentBulletCountInMagazine;

        private void Update() => _elapsedTime += Time.deltaTime;

        public override void Fire()
        {
            if(_elapsedTime < Data.FiringRate) return;
            if (_currentBulletCountInMagazine == 0)
            {
                Reload();
                return;
            }

            AmmunitionFactory.Create(AmmunitionType.Bullet, ShootPoint);
            _currentBulletCountInMagazine--;
            _elapsedTime = 0;
        }

        private void Reload()
        {
            _currentBulletCountInMagazine = 20;
            _elapsedTime = -Data.ReloadTime;
        }
    }
}