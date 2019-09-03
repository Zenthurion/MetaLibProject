using System;
using System.Collections.Generic;

namespace MetaLib.FSM
{
    public abstract class State : IState
    {
        private StateState _stateState = StateState.Idle;
        private readonly Dictionary<StatePhase, HashSet<ITransition>> _transitions;

        protected State(IFiniteStateMachine owner, string name)
        {
            _transitions = new Dictionary<StatePhase, HashSet<ITransition>>();
            FSM = owner;
            Name = name;
        }

        public void AddTransition(StatePhase phase, ITransition transition)
        {
            if (_transitions.TryGetValue(phase, out var t))
                t.Add(transition);
            else
            {
                var set = new HashSet<ITransition>();
                _transitions.Add(phase, set);
                set.Add(transition);
            } 
                
        }

        public void RemoveTransition(StatePhase phase, ITransition transition)
        {
            if (_transitions.TryGetValue(phase, out var t))
                t.Remove(transition);
        }

        public string Name { get; private set; }
        
        public IFiniteStateMachine FSM { get; }

        public void Update()
        {
            if (_stateState != StateState.Running) return;
            ProcessTransitions(StatePhase.Update);
            StateUpdate();
        }

        public void FixedUpdate()
        {
            if (_stateState != StateState.Running) return;
            ProcessTransitions(StatePhase.FixedUpdate);
            StateFixedUpdate();
        }

        public void LateUpdate()
        {
            if (_stateState != StateState.Running) return;
            ProcessTransitions(StatePhase.LateUpdate);
            StateLateUpdate();
        }

        public void Enter()
        {
            if (_stateState != StateState.Idle) return;
            _stateState = StateState.Running;
            ProcessTransitions(StatePhase.Enter);
            StateEnter();
        }

        public void Exit()
        {
            if (_stateState != StateState.Running) return;
            _stateState = StateState.Idle;
            ProcessTransitions(StatePhase.Exit);
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

        protected virtual void StateExit()
        {
        }

        private void ProcessTransitions(StatePhase phase)
        {
            if (!_transitions.TryGetValue(phase, out var t)) return;
            foreach (var x in t)
            {
                if(x.Evaluate()) x.Execute();
            }
        }

        private enum StateState
        {
            Idle,
            Running
        }
    }
}