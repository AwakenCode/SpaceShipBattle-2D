using UnityEngine;

namespace Ship.Ammunition
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