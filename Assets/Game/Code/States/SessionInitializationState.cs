using Game.Code.Core;
using Game.Code.Services;

namespace Game.Code.States
{
    public class SessionInitializationState : IState
    {
        
        private readonly StateMachine _stateMachine;
        private readonly PresenterService _presenterService;
        private int _pick;


        public SessionInitializationState(StateMachine stateMachine, PresenterService presenterService)
        {
            _stateMachine = stateMachine;
            _presenterService = presenterService;
        }

        public void Enter()
        {
            _presenterService.Initialize();
            _presenterService.InfoPresenter.EnableView();
            _presenterService.InfoPresenter.SetText("PICK A NUMBER");
            
            _presenterService.GuessPresenter.EnableView();
            _presenterService.GuessPresenter.SetText("#$*&");

            _presenterService.TurnStatusPresenter.DisableView();
            _presenterService.InputPresenter.DisableView();

            _presenterService.StartButtonPresenter.EnableView();
            _presenterService.StartButtonPresenter.SetText("Start");
            _presenterService.StartButtonPresenter.onStartClicked += StartGame;
        }

        public void Exit()
        {
            _presenterService.StartButtonPresenter.DisableView();
        }

        private void StartGame()
        {
            _presenterService.StartButtonPresenter.onStartClicked -= StartGame;
            _stateMachine.EnterState<PickingNumberState>();
        }
    }
}