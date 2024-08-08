using Game.Code.Views;

namespace Game.Code.Core
{
    public class GameInstance
    {
        public readonly StateMachine StateMachine;

        public GameInstance(LoadingView loadingView)
        {
            StateMachine = new StateMachine(loadingView);
        }
    }
}