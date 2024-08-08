using System;

namespace Game.Code.Services
{
    public class SceneLoader
    {
        private readonly IResourceProvider _resourceProvider;

        public SceneLoader(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }

        public async void LoadSceneAsync(string sceneName, Action onLoaded)
        {
            await _resourceProvider.LoadSceneAsync(sceneName);
            onLoaded?.Invoke();
        }
    }
}