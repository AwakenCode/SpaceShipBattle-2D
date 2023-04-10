using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;

namespace Service.Pool
{
    public class PlasmaPool
    {
        private readonly ObjectPool<Plasma> _pool;
        private readonly Transform _container;

        public PlasmaPool(Transform container)
        {
            _container = container;
            _pool = new ObjectPool<Plasma>(OnDestroyed, OnGot, OnReleased);
        }
        
        public int InactiveCount => _pool.CountInactive;

        public Plasma Get() => _pool.Get();

        public void Release(Plasma entity) => _pool.Release(entity);

        public void Dispose() => _pool.Dispose();

        private void OnReleased(Plasma plasma)
        {
            plasma.transform.SetParent(_container);
            plasma.gameObject.SetActive(false);
        }

        private void OnDestroyed(Plasma plasma) => Object.Destroy(plasma.gameObject);

        private void OnGot(Plasma plasma) => plasma.gameObject.SetActive(true);
    }
}