using Game.Code.Views;
using Object = UnityEngine.Object;

namespace Game.Code.Services
{
    public class UIFactory
    {
        private readonly IResourceProvider _resourceProvider;
        private HudView _instance;

        public UIFactory(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }
        
        public HudView CreateUI()
        {
            if (_instance != null) 
                return _instance;
            
            var prefab = _resourceProvider.LoadHud();
            _instance = Object.Instantiate(prefab).GetComponent<HudView>();
            return _instance;
        }
    }
}