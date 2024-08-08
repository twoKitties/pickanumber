using Game.Code.Core;
using Game.Code.Services;

namespace Game.Code.States
{
    public class PlayerInputState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterService _presenterService;

        public PlayerInputState(StateMachine stateMachine, PresenterService presenterService)
        {
            _stateMachine = stateMachine;
            _presenterService = presenterService;
        }

        public void Enter(PlayerData playerData)
        {
            _presenterService.GuessPresenter.EnableView();
            _presenterService.TurnStatusPresenter.EnableView();
            _presenterService.TurnStatusPresenter.SetText($"{playerData.Name}'S TURN");
            _presenterService.GuessPresenter.SetText("");
            _presenterService.InputPresenter.EnableView();
            _presenterService.InputPresenter.AddCallback(() => _stateMachine.EnterState<CheckInputState, PlayerData>(playerData));
        }

        public void Exit()
        {
            _presenterService.InputPresenter.Reset();
            _presenterService.InputPresenter.DisableView();
            _presenterService.InputPresenter.AddCallback(null);
        }
    }
}