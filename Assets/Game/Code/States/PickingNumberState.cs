using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Services;

namespace Game.Code.States
{
    public class PickingNumberState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly GameStateModel _gameStateModel;
        private readonly PresenterProvider _presenterProvider;

        public PickingNumberState(StateMachine stateMachine, GameStateModel gameStateModel, PresenterProvider presenterProvider)
        {
            _stateMachine = stateMachine;
            _gameStateModel = gameStateModel;
            _presenterProvider = presenterProvider;
        }

        public void Enter()
        {
            _gameStateModel.Generate();
            _presenterProvider.TurnStatusPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.SetText("PICKING A NUMBER");

            _presenterProvider.InfoPresenter.EnableView();
            _presenterProvider.InfoPresenter.RunWithDelay(() => _stateMachine.EnterState<SelectPlayerState>());
            _presenterProvider.InputPresenter.DisableView();
            _presenterProvider.StartButtonPresenter.DisableView();
            
            _presenterProvider.GuessPresenter.EnableView();
            _presenterProvider.GuessPresenter.SetText("####");
        }

        public void Exit()
        {
            
        }
    }
}