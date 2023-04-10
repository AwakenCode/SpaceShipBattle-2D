using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Service.Asset
{
    public interface IAssetProvider
    {
        void Initialize();
        Task PrepareFor(string sceneName);
        void Clean();
        GameObject Load(string address);
        GameObject Load(AssetReference assetReference);
        Task<GameObject> LoadAsync(string address);
        Task<GameObject> LoadAsync(AssetReference assetReference);
    }
}