namespace _Project.Scripts.Infrastructure.FSM.State
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}