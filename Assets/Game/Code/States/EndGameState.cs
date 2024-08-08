using Game.Code.Core;
using Game.Code.Services;
using UnityEngine;

namespace Game.Code.States
{
    public class EndGameState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterProvider _presenterProvider;

        public EndGameState(StateMachine stateMachine, PresenterProvider presenterProvider)
        {
            _stateMachine = stateMachine;
            _presenterProvider = presenterProvider;
        }

        public void Enter(PlayerData playerData)
        {
            var color = playerData.IsLocal ? Color.green : Color.yellow;
            _presenterProvider.GuessPresenter.SetTextColor(color);
            _presenterProvider.InfoPresenter.SetText($"{playerData.Name} WON");
            _presenterProvider.InfoPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.SetText("GAME OVER");
            _presenterProvider.StartButtonPresenter.SetText("RESTART");
            _presenterProvider.StartButtonPresenter.onStartClicked += Restart;
            _presenterProvider.StartButtonPresenter.EnableView();
        }

        public void Exit()
        { 
            _presenterProvider.GuessPresenter.SetTextColor(Color.white);
            _presenterProvider.InfoPresenter.SetText("");
        }

        private void Restart()
        {
            _presenterProvider.StartButtonPresenter.onStartClicked -= Restart;
            _stateMachine.EnterState<PickingNumberState>();
        }
    }
}