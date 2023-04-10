namespace Infrastructure.State.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IState;
        void AddState<TState>(IState state) where TState : IState;
    }
}