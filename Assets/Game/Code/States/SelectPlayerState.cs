using Game.Code.Core;
using Game.Code.Models;
using Game.Code.Services;

namespace Game.Code.States
{
    public class SelectPlayerState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly PlayerModel _playerModel;
        private int _playerIndex;

        public SelectPlayerState(StateMachine stateMachine, PlayerModel playerModel)
        {
            _stateMachine = stateMachine;
            _playerModel = playerModel;
        }
        
        public void Enter()
        {
            _playerIndex = _playerModel.ActivePlayerIndex;
            var playerData = _playerModel.Data[_playerIndex];
            
            if (playerData.IsLocal)
            {
                _stateMachine.EnterState<PlayerInputState, PlayerData>(playerData);
            }
            else
            {
                _stateMachine.EnterState<OpponentInputState, PlayerData>(playerData);
            }
        }

        public void Exit()
        {
            _playerIndex++;
            if (_playerIndex > _playerModel.Count - 1)
            {
                _playerIndex = 0;
            }
            
            _playerModel.ActivePlayerIndex = _playerIndex;
        }
    }
}