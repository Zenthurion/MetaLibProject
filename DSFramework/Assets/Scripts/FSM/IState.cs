namespace FSM
{
    public interface IState
    {
        void Update();
        void FixedUpdate();
        void LateUpdate();

        void Enter();
        void Exit();
    }
}