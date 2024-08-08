using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Services;
using PrimeTween;
using UnityEngine;

namespace Game.Code.States
{
    public class CheckInputState : IPayloadedState<PlayerData>
    {
        private readonly StateMachine _stateMachine;
        private readonly PresenterProvider _presenterProvider;
        private readonly GameStateModel _gameStateModel;
        private readonly InputModel _inputModel;

        public CheckInputState(StateMachine stateMachine, PresenterProvider presenterProvider, GameStateModel gameStateModel, InputModel inputModel)
        {
            _stateMachine = stateMachine;
            _presenterProvider = presenterProvider;
            _gameStateModel = gameStateModel;
            _inputModel = inputModel;
        }

        public void Enter(PlayerData playerData)
        {
            _presenterProvider.InfoPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.EnableView();
            _presenterProvider.TurnStatusPresenter.SetText("CHECKING");
            CheckWinCondition(playerData);
        }

        public void Exit()
        {
            _presenterProvider.InfoPresenter.DisableView();
            _presenterProvider.GuessPresenter.SetTextColor(Color.white);
            _inputModel.Reset();
        }

        private void CheckWinCondition(PlayerData playerData)
        {
            var currentAnswer = _inputModel.Value;
            var guessedNumber = _gameStateModel.GuessedNumber;
            var text = string.Empty;
            var color = Color.white;
            var sequence = Sequence.Create();

            if (currentAnswer == guessedNumber)
            {
                sequence.Chain(Tween.Delay(1f, () => _stateMachine.EnterState<EndGameState, PlayerData>(playerData)));
            }
            else
            {
                var isBigger = currentAnswer > guessedNumber; 
                text = isBigger ? "TOO BIG" : "TOO SMALL";
                color = Color.red;
                
                var lastAnswer = playerData.LastAnswer;
                switch (isBigger)
                {
                    case true when currentAnswer < lastAnswer:
                        _gameStateModel.ClosestMax = currentAnswer;
                        break;
                    case false when currentAnswer > lastAnswer:
                        _gameStateModel.ClosestMin = currentAnswer;
                        break;
                }

                playerData.LastAnswer = currentAnswer;
                Tween.Delay(1f, () => _stateMachine.EnterState<SelectPlayerState>());
            }
            
            _inputModel.Reset();
            _presenterProvider.InfoPresenter.SetText(text);
            _presenterProvider.GuessPresenter.SetTextColor(color);
        }
    }
}