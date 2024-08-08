namespace Game.Code.Core
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}