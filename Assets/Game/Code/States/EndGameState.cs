using Game.Code.Core;
using Game.Code.Services;
using UnityEngine;

namespace Game.Code.States
{
    public class EndGameState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterService _presenterService;

        public EndGameState(StateMachine stateMachine, PresenterService presenterService)
        {
            _stateMachine = stateMachine;
            _presenterService = presenterService;
        }

        public void Enter(PlayerData playerData)
        {
            var color = playerData.IsLocal ? Color.green : Color.yellow;
            _presenterService.GuessPresenter.SetTextColor(color);
            _presenterService.InfoPresenter.SetText($"{playerData.Name} WON");
            _presenterService.InfoPresenter.EnableView();
            _presenterService.TurnStatusPresenter.SetText("GAME OVER");
            _presenterService.StartButtonPresenter.SetText("RESTART");
            _presenterService.StartButtonPresenter.onStartClicked += Restart;
            _presenterService.StartButtonPresenter.EnableView();
        }

        public void Exit()
        { 
            _presenterService.GuessPresenter.SetTextColor(Color.white);
        }

        private void Restart()
        {
            _presenterService.StartButtonPresenter.onStartClicked -= Restart;
            _stateMachine.EnterState<PickingNumberState>();
        }
    }
}