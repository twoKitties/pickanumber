using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Code.Services
{
    public class ResourceProvider : IResourceProvider
    {
        private const string SceneFolderPath = "Assets/Game/Scenes/";
        private const string SceneExtension = ".unity";
        private GameObject _hudView;

        public async Task Initialize()
        {
            try
            {
                var path = $"Assets/Game/Prefabs/GameUI.prefab";
                var operationHandle = Addressables.LoadAssetAsync<GameObject>(path);
                await operationHandle.Task;
                _hudView = operationHandle.Result;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
        
        public async Task LoadSceneAsync(string sceneName)
        {
            try
            {
                var path = $"{SceneFolderPath}{sceneName}{SceneExtension}";
                var operationHandle = Addressables.LoadSceneAsync(path);
                await operationHandle.Task;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        public GameObject LoadHud()
        {
            return _hudView;
        }
    }
}