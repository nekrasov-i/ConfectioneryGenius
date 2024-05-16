using _Project.Scripts.Infrastructure.FSM.State;

namespace _Project.Scripts.Infrastructure.FSM
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>;
    }
}