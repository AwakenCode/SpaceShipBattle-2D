using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;

namespace Service.Pool
{
    public class BulletPool
    {
        private readonly ObjectPool<Bullet> _pool;
        private readonly Transform _container;
        
        public BulletPool(Transform container)
        {
            _container = container;
            _pool = new ObjectPool<Bullet>(OnDestroyed, OnGot, OnReleased);
        }

        public int InactiveCount => _pool.CountInactive;

        public Bullet Get() => _pool.Get();

        public void Release(Bullet entity) => _pool.Release(entity);

        public void Dispose() => _pool.Dispose();

        private void OnReleased(Bullet bullet)
        {
            bullet.transform.SetParent(_container);
            bullet.gameObject.SetActive(false);
        }

        private void OnDestroyed(Bullet bullet) => Object.Destroy(bullet.gameObject);

        private void OnGot(Bullet bullet) => bullet.gameObject.SetActive(true);
    }
}