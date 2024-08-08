using Game.Code.Core;
using Game.Code.Services;

namespace Game.Code.States
{
    public class SelectPlayerState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly PlayersModel _playersModel;
        private int _playerIndex;

        public SelectPlayerState(StateMachine stateMachine, PlayersModel playersModel)
        {
            _stateMachine = stateMachine;
            _playersModel = playersModel;
        }
        
        public void Enter()
        {
            _playerIndex = _playersModel.ActivePlayerIndex;
            var playerData = _playersModel.Data[_playerIndex];
            
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
            if (_playerIndex > _playersModel.Count - 1)
            {
                _playerIndex = 0;
            }
            
            _playersModel.ActivePlayerIndex = _playerIndex;
        }
    }
}