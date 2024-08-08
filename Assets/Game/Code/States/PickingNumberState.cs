using Game.Code.Core;
using Game.Code.Services;

namespace Game.Code.States
{
    public class PickingNumberState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly GameStateModel _gameStateModel;
        private readonly PresenterService _presenterService;

        public PickingNumberState(StateMachine stateMachine, GameStateModel gameStateModel, PresenterService presenterService)
        {
            _stateMachine = stateMachine;
            _gameStateModel = gameStateModel;
            _presenterService = presenterService;
        }

        public void Enter()
        {
            _gameStateModel.Generate();
            _presenterService.TurnStatusPresenter.EnableView();
            _presenterService.TurnStatusPresenter.SetText("PICKING A NUMBER");

            _presenterService.InfoPresenter.EnableView();
            _presenterService.InfoPresenter.RunWithDelay(() => _stateMachine.EnterState<SelectPlayerState>());
            _presenterService.InputPresenter.DisableView();
            _presenterService.StartButtonPresenter.DisableView();
            
            _presenterService.GuessPresenter.EnableView();
            _presenterService.GuessPresenter.SetText("####");
        }

        public void Exit()
        {
            
        }
    }
}