using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Services;

namespace Game.Code.States
{
    public class PlayerInputState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterProvider _presenterProvider;

        public PlayerInputState(StateMachine stateMachine, PresenterProvider presenterProvider)
        {
            _stateMachine = stateMachine;
            _presenterProvider = presenterProvider;
        }

        public void Enter(PlayerData playerData)
        {
            _presenterProvider.GuessPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.SetText($"{playerData.Name}'S TURN");
            _presenterProvider.GuessPresenter.SetText("");
            _presenterProvider.InputPresenter.EnableView();
            _presenterProvider.InputPresenter.AddCallback(() => _stateMachine.EnterState<CheckInputState, PlayerData>(playerData));
        }

        public void Exit()
        {
            _presenterProvider.InputPresenter.Reset();
            _presenterProvider.InputPresenter.DisableView();
            _presenterProvider.InputPresenter.AddCallback(null);
        }
    }
}