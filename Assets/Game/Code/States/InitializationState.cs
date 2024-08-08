using System;
using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Presenters;
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
            
            var random = new Random(UnityEngine.Random.Range(-100, 100));
            var max = 9;
            var gameStateModel = new GameStateModel(random, max);
            var inputModel = new InputModel(gameStateModel.Max);
            var playersModel = new DataFactory().CreatePlayers();
            
            var resourceProvider = new ResourceProvider();
            var uiFactory = new UIFactory(resourceProvider);
            var presenterService = new PresenterProvider(uiFactory, inputModel);
            
            //ServiceLocator.Register();
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            _loadingView.SetActive(false);
            _stateMachine.EnterState<SessionInitializationState>();
        }
    }
}