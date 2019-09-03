namespace MetaLib.FSM
{
    public interface IState
    {
        string Name { get; }
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void Enter();
        void Exit();

        void AddTransition(StatePhase phase, ITransition transition);
        void RemoveTransition(StatePhase phase, ITransition transition);
    }
}