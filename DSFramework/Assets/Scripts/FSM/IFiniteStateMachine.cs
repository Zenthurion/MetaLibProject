namespace FSM
{
    public interface IFiniteStateMachine
    {
        IState CurrentState { get; }
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void AddState(IState state);
        void SetInitialState(IState state);
        void ChangeState(IState state);
    }
}