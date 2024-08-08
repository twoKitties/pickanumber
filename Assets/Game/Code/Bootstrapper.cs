using Game.Code.States;
using Game.Code.Views;
using UnityEngine;

namespace Game.Code
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private LoadingView _loadingView;
        private GameInstance _game;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _game = new GameInstance(_loadingView);
            _game.StateMachine.EnterState<InitializationState>();
        }
    }
}
