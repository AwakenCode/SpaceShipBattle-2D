using Ship.Equipment.Weapon;
using Ship.Weapon;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Weapon
{
    [CreateAssetMenu(menuName = "Weapon/Data", order = 61)]
    public class WeaponData : ScriptableObject
    {
        [field: SerializeField] public WeaponType Type { get; private set; }
        [field: SerializeField] public float DamageFactor { get; private set; }
        [field: SerializeField] public float FiringRate { get; private set; }
        [field: SerializeField] public float ReloadTime { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public AssetReference Template { get; private set; }
    }
}