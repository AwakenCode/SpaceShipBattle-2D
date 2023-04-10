using Ship.Equipment.Weapon.Ammunition;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Ammunition
{
    [CreateAssetMenu(menuName = "Ammunition/Data", order = 61)]
    public class AmmunitionData : ScriptableObject
    {
        [field: SerializeField] public AmmunitionType Type { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }
        [field: SerializeField] public AssetReference Template { get; private set; }
    }
}