using Ship;
using Ship.Weapon;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Ship
{
    [CreateAssetMenu(menuName = "Ship/Data", order = 61)]
    public class ShipData : ScriptableObject
    {
        [field: SerializeField] public ShipType Type { get; private set; }
        [field: SerializeField] public uint Hp { get; private set; }
        [field: SerializeField] public uint Shield { get; private set; }
        [field: SerializeField] public uint ShieldRecovery { get; private set; }
        [field: SerializeField] public float ShieldRecoveryDelay { get; private set; }
        [field: SerializeField, Range(0, 2)] public uint WeaponCount { get; private set; }
        [field: SerializeField, Range(0, 3)] public uint ModuleCount { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public AssetReference Template { get; private set; }
    }
}