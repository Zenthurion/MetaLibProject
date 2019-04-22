namespace DwarvenSoftware.Framework.FSM
{
    public interface IState
    {
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void Enter();
        void Exit();

        void AddTransition(StatePhase phase, ITransition transition);
        void RemoveTransition(StatePhase phase, ITransition transition);
    }
}