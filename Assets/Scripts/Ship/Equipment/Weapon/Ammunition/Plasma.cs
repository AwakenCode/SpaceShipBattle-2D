using System;
using Data.Ammunition;
using Service.Data;
using UnityEngine;
using Zenject;

namespace Ship.Equipment.Weapon.Ammunition
{
    public class Plasma : MonoBehaviour
    {
        private AmmunitionData _data;
        private float _elapsedTime;
        
        public event Action<Plasma> Destroyed;

        [Inject]
        private void Construct(IDataProvider dataProvider)
        {
            _data = dataProvider.GetAmmunitionData(AmmunitionType.Plasma);
        }

        private void OnTriggerStay(Collider other)
        {
            DealDamage(other);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            transform.Translate(_data.Speed * Time.deltaTime * Vector3.right);
            
            if (_elapsedTime >= _data.LifeTime)
                Destroy();
        }

        private void DealDamage(Collider other)
        {
            if(other.TryGetComponent(out IHealth health))
                health.TakeDamage(_data.Damage);

            Destroy();
        }

        private void Destroy()
        {
            _elapsedTime = 0;
            Destroyed?.Invoke(this);
        } 
    }
}