using Game.Code.Core;
using Game.Code.Services;

namespace Game.Code.States
{
    public class MenuState : IState
    {
        
        private readonly StateMachine _stateMachine;
        private readonly PresenterProvider _presenterProvider;


        public MenuState(StateMachine stateMachine, PresenterProvider presenterProvider)
        {
            _stateMachine = stateMachine;
            _presenterProvider = presenterProvider;
        }

        public void Enter()
        {
            _presenterProvider.Initialize();
            _presenterProvider.InfoPresenter.EnableView();
            _presenterProvider.InfoPresenter.SetText("PICK A NUMBER");
            
            _presenterProvider.GuessPresenter.EnableView();
            _presenterProvider.GuessPresenter.SetText("#$*&");

            _presenterProvider.TurnStatusPresenter.DisableView();
            _presenterProvider.InputPresenter.DisableView();

            _presenterProvider.StartButtonPresenter.EnableView();
            _presenterProvider.StartButtonPresenter.SetText("Start");
            _presenterProvider.StartButtonPresenter.onStartClicked += StartGame;
        }

        public void Exit()
        {
            _presenterProvider.StartButtonPresenter.DisableView();
        }

        private void StartGame()
        {
            _presenterProvider.StartButtonPresenter.onStartClicked -= StartGame;
            _stateMachine.EnterState<PickingNumberState>();
        }
    }
}