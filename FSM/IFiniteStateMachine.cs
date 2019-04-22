namespace DwarvenSoftware.Framework.FSM
{
    public interface IFiniteStateMachine
    {
        IState CurrentState { get; }
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void AddState(params IState[] state);
        void SetInitialState(IState state);
        void ChangeState(IState state);
    }
}