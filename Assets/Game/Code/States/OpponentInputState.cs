using System;
using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Services;
using PrimeTween;

namespace Game.Code.States
{
    public class OpponentInputState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterService _presenterService;
        private readonly Bot _bot;
        private readonly InputModel _inputModel;
        private readonly Random _random;

        public OpponentInputState(StateMachine stateMachine, PresenterService presenterService, Bot bot, InputModel inputModel)
        {
            _stateMachine = stateMachine;
            _presenterService = presenterService;
            _bot = bot;
            _inputModel = inputModel;
        }
        
        public void Enter(PlayerData playerData)
        {
            _presenterService.TurnStatusPresenter.EnableView();
            _presenterService.TurnStatusPresenter.SetText($"{playerData.Name}'S TURN");
            _presenterService.GuessPresenter.SetText("");
            
            Sequence.Create()
                .Chain(Tween.Delay(1f, () =>
                    {
                        var guess = _bot.GetNumber();
                        _inputModel.Value = guess;
                        _presenterService.GuessPresenter.SetText(guess.ToString());
                    }))
                .ChainDelay(1f)
                .ChainCallback(() => _stateMachine.EnterState<CheckInputState, PlayerData>(playerData));
        }

        public void Exit()
        {
            _presenterService.TurnStatusPresenter.DisableView();
        }
    }
}