using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Service.Asset
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _loadedAssets = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();
        
        private IDataProvider _dataProvider;

        [Inject]
        private void Construct(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        
        public void Initialize() => Addressables.InitializeAsync();

        public async Task PrepareFor(string sceneName)
        {
            var assetReferences = _dataProvider
                .GetSceneData()
                .GetAssetReferencesFor(sceneName);

            foreach (var assetReference in assetReferences) 
                await LoadAsync(assetReference);
        }
        
        public void Clean()
        {
            foreach (var handle in _handles.Values.SelectMany(assetHandles => assetHandles))
                Addressables.Release(handle);
        }

        public GameObject Load(string address) => 
            _loadedAssets[address].Result as GameObject;

        public GameObject Load(AssetReference assetReference) => 
            _loadedAssets[assetReference.AssetGUID].Result as GameObject;

        public async Task<GameObject> LoadAsync(string address)
        {
            if (_loadedAssets.ContainsKey(address))
                return Load(address);

            return await LoadWithCacheOnComplete(Addressables.LoadAssetAsync<GameObject>(address), address);
        }

        public async Task<GameObject> LoadAsync(AssetReference assetReference)
        {
            if (_loadedAssets.ContainsKey(assetReference.AssetGUID))
                return Load(assetReference.AssetGUID);

            return await LoadWithCacheOnComplete(Addressables.LoadAssetAsync<GameObject>(assetReference), assetReference.AssetGUID);
        }

        private async Task<T> LoadWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string key) where T : class
        {
            handle.Completed += loadedAsset =>
                _loadedAssets.Add(key, loadedAsset);
            
            AddHandle(handle, key);
            return await handle.Task;
        }

        private void AddHandle(AsyncOperationHandle handle, string key)
        {
            if (_handles.TryGetValue(key, out var handles) == false)
            {
                handles = new List<AsyncOperationHandle>();
                _handles[key] = handles;
            }
            
            handles.Add(handle);  
        } 
    }
}