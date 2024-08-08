using System;
using System.Collections.Generic;
using Game.Code.Models;
using Game.Code.Services;
using Game.Code.States;
using Game.Code.Views;

namespace Game.Code.Core
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public StateMachine(LoadingView loadingView)
        {
            var random = new Random(UnityEngine.Random.Range(-100, 100));
            var max = 9;
            var gameStateModel = new GameStateModel(random, max);
            var inputModel = new InputModel(gameStateModel.Max);
            
            var resourceProvider = new ResourceProvider();
            var uiFactory = new UIFactory(resourceProvider);
            var playerFactory = new PlayerFactory();
            var playersModel = playerFactory.Create();
            var presenterService = new PresenterService(uiFactory, inputModel);
            
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(InitializationState)] = new InitializationState(this, 
                    new SceneLoader(resourceProvider), 
                    resourceProvider, 
                    loadingView),
                [typeof(SessionInitializationState)] = new SessionInitializationState(this, presenterService),
                [typeof(PickingNumberState)] = new PickingNumberState(this, gameStateModel, presenterService),
                [typeof(SelectPlayerState)] = new SelectPlayerState(this, playersModel),
                [typeof(PlayerInputState)] = new PlayerInputState(this, presenterService),
                [typeof(OpponentInputState)] = new OpponentInputState(this, presenterService, new Bot(0, max, gameStateModel), inputModel),
                [typeof(CheckInputState)] = new CheckInputState(this, presenterService, gameStateModel, inputModel),
                [typeof(EndGameState)] = new EndGameState(this, presenterService)
            };
        }

        public void EnterState<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        public void EnterState<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            var state = _states[typeof(TState)];
            _currentState = state;
            return state as TState;
        }
    }
}