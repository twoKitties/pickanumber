using System;
using System.Collections.Generic;
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
            var random = new Random(UnityEngine.Random.Range(0, 100));
            const int max = 9;
            var resourceProvider = new ResourceProvider();
            var uiFactory = new UIFactory(resourceProvider);
            
            var modelProvider = new ModelProvider(random, max);
            var presenterService = new PresenterProvider(uiFactory, modelProvider.InputModel);

            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(InitializationState)] = new InitializationState(this, new SceneLoader(resourceProvider), resourceProvider, loadingView),
                [typeof(SessionInitializationState)] = new SessionInitializationState(this, presenterService),
                [typeof(PickingNumberState)] = new PickingNumberState(this, modelProvider.GameStateModel, presenterService),
                [typeof(SelectPlayerState)] = new SelectPlayerState(this, modelProvider.PlayerModel),
                [typeof(PlayerInputState)] = new PlayerInputState(this, presenterService),
                [typeof(OpponentInputState)] = new OpponentInputState(this, presenterService, modelProvider.GameStateModel, modelProvider.InputModel),
                [typeof(CheckInputState)] = new CheckInputState(this, presenterService, modelProvider.GameStateModel, modelProvider.InputModel),
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