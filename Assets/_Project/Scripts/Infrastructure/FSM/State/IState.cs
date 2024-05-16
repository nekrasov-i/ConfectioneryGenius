namespace _Project.Scripts.Infrastructure.FSM.State
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}