using Game.Code.Core;
using Game.Code.Services;
using Game.Code.Views;

namespace Game.Code.States
{
    public class InitializationState : IState
    {
        private readonly IResourceProvider _resourceProvider;
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingView _loadingView;

        public InitializationState(StateMachine stateMachine, SceneLoader sceneLoader,
            IResourceProvider resourceProvider,
            LoadingView loadingView)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _resourceProvider = resourceProvider;
            _loadingView = loadingView;
        }
        
        public async void Enter()
        {
            await _resourceProvider.Initialize();
            _sceneLoader.LoadSceneAsync("Game", OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            _loadingView.SetActive(false);
            _stateMachine.EnterState<MenuState>();
        }
    }
}