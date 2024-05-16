using _Project.Scripts.Infrastructure.FSM.State;

namespace _Project.Scripts.Infrastructure.FSM
{
    public interface IGameStateMachine : IStateMachine
    {
        IExitableState CurrentState { get; }
    }
}