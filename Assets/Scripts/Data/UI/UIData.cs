using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.UI
{
    [CreateAssetMenu(menuName = "UI/Data", order = 61)]
    public class UIData : ScriptableObject
    {
        [field: SerializeField] public AssetReference Curtain { get; private set; }
        [field: SerializeField] public AssetReference ShipSetupWindow { get; private set; }
        [field: SerializeField] public AssetReference Slot { get; private set; }
        [field: SerializeField] public AssetReference BattleWindow { get; private set; }
    }
}