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
        private readonly PresenterProvider _presenterProvider;
        private readonly GameStateModel _gameStateModel;
        private readonly Bot _bot;
        private readonly InputModel _inputModel;
        private readonly Random _random;

        public OpponentInputState(StateMachine stateMachine, PresenterProvider presenterProvider, GameStateModel gameStateModel, InputModel inputModel)
        {
            _stateMachine = stateMachine;
            _presenterProvider = presenterProvider;
            _gameStateModel = gameStateModel;
            //TODO reset bot on restart
            _bot = new Bot(gameStateModel);
            _inputModel = inputModel;
        }
        
        public void Enter(PlayerData playerData)
        {
            _presenterProvider.TurnStatusPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.SetText($"{playerData.Name}'S TURN");
            _presenterProvider.GuessPresenter.SetText("");
            
            Sequence.Create()
                .Chain(Tween.Delay(1f, () =>
                    {
                        var guess = _bot.GetNumber();
                        _inputModel.Value = guess;
                        _presenterProvider.GuessPresenter.SetText(guess.ToString());
                    }))
                .ChainDelay(1f)
                .ChainCallback(() => _stateMachine.EnterState<CheckInputState, PlayerData>(playerData));
        }

        public void Exit()
        {
            _presenterProvider.TurnStatusPresenter.DisableView();
        }
    }
}