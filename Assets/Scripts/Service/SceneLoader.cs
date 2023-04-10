using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Service
{
    public class SceneLoader
    {
        public async void LoadSceneAsync(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                return;
            }
            
            await Addressables.LoadSceneAsync(name).Task;
            onLoaded?.Invoke();
        }
        
        public void AddDontDestroyObject(GameObject gameObject)
        {
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public void RemoveDontDestroyObject(GameObject gameObject)
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
    }
}