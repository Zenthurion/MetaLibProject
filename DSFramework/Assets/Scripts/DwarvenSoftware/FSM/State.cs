namespace DwarvenSoftware.FSM
{
    public abstract class State : IState
    {
        private StateState _stateState = StateState.Idle;


        protected State(IFiniteStateMachine owner)
        {
            FSM = owner;
        }

        public IFiniteStateMachine FSM { get; }

        public void Update()
        {
            if (_stateState != StateState.Running) return;
            StateUpdate();
        }

        public void FixedUpdate()
        {
            if (_stateState != StateState.Running) return;
            StateFixedUpdate();
        }

        public void LateUpdate()
        {
            if (_stateState != StateState.Running) return;
            StateLateUpdate();
        }

        public void Enter()
        {
            if (_stateState != StateState.Idle) return;
            _stateState = StateState.Running;
            StateEnter();
        }

        public void Exit()
        {
            if (_stateState != StateState.Running) return;
            _stateState = StateState.Idle;
            StateExit();
        }

        protected virtual void StateUpdate()
        {
        }

        protected virtual void StateFixedUpdate()
        {
        }

        protected virtual void StateLateUpdate()
        {
        }

        protected virtual void StateEnter()
        {
        }

        public virtual void StateExit()
        {
        }

        private enum StateState
        {
            Idle,
            Running
        }
    }
}