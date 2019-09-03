namespace DwarvenSoftware.Framework.FSM
{
    public delegate void StateChangeEvent(IState newState, IState previousState);
    public interface IFiniteStateMachine
    {
        event StateChangeEvent OnStateChange;
        IState CurrentState { get; }
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void AddState(params IState[] state);
        void SetInitialState(IState state);
        void ChangeState(IState state);
    }
}