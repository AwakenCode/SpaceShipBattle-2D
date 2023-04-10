using UnityEngine;

namespace Ship.Equipment.Weapon.Ammunition
{
    [RequireComponent(typeof(Animator))]
    public class AmmunitionAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}