using System;

namespace FSM
{
    public abstract class State : IState
    {
        private enum StateState
        {
            Idle,
            Running
        }

        public IFiniteStateMachine FSM { get; }

        private StateState _stateState = StateState.Idle;


        protected State(IFiniteStateMachine owner)
        {
            FSM = owner;
        }

        protected virtual void StateUpdate()
        {
        }

        public void Update()
        {
            if (_stateState != StateState.Running) return;
            StateUpdate();
        }

        protected virtual void StateFixedUpdate()
        {
        }

        public void FixedUpdate()
        {
            if (_stateState != StateState.Running) return;
            StateFixedUpdate();
        }

        protected virtual void StateLateUpdate()
        {
        }

        public void LateUpdate()
        {
            if (_stateState != StateState.Running) return;
            StateLateUpdate();
        }

        protected virtual void StateEnter()
        {
        }

        public void Enter()
        {
            if (_stateState != StateState.Idle) return;
            _stateState = StateState.Running;
            StateEnter();
        }

        public virtual void StateExit()
        {
        }

        public void Exit()
        {
            if (_stateState != StateState.Running) return;
            _stateState = StateState.Idle;
            StateExit();
        }
    }
}