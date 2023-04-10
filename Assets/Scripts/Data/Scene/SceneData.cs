using System;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Scene
{
    [CreateAssetMenu(menuName = "Scene/Data", order = 61)]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private AssetReference[] _setupSceneAssets;
        [SerializeField] private AssetReference[] _battleSceneAssets;
        
        public IEnumerable<AssetReference> GetAssetReferencesFor(string sceneName)
        {
            return sceneName switch
            {
                Constants.ShipSetupSceneName => _setupSceneAssets,
                Constants.BattleSceneName => _battleSceneAssets,
                _ => throw new ArgumentOutOfRangeException(nameof(sceneName))
            };
        }
    }
}