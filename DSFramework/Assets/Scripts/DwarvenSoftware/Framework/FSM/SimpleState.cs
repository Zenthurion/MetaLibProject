namespace DwarvenSoftware.Framework.FSM
{
    public delegate void StateEvent<T>(T state) where T : IState;

    public class SimpleState : State
    {
        public SimpleState(IFiniteStateMachine owner) : base(owner)
        {
        }

        public event StateEvent<SimpleState> OnUpdate;
        public event StateEvent<SimpleState> OnFixedUpdate;
        public event StateEvent<SimpleState> OnLateUpdate;
        public event StateEvent<SimpleState> OnEnter;
        public event StateEvent<SimpleState> OnExit;

        protected override void StateUpdate()
        {
            base.StateUpdate();
            OnUpdate?.Invoke(this);
        }

        protected override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            OnFixedUpdate?.Invoke(this);
        }

        protected override void StateLateUpdate()
        {
            base.StateLateUpdate();
            OnLateUpdate?.Invoke(this);
        }

        protected override void StateEnter()
        {
            base.StateEnter();
            OnEnter?.Invoke(this);
        }

        public override void StateExit()
        {
            base.StateExit();
            OnExit?.Invoke(this);
        }
    }
}