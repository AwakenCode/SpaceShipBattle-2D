using UnityEngine;

namespace Common
{
    public class AmmunitionContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletPoolContainer { get; private set; }
        [field: SerializeField] public Transform PlasmaPoolContainer { get; private set; }
    }
}