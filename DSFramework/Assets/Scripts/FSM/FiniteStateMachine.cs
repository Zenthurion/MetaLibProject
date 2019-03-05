using System.Collections.Generic;

namespace FSM
{
    public class FiniteStateMachine : IFiniteStateMachine
    {
        public IState CurrentState { get; private set; }
        List<IState> _states;

        public FiniteStateMachine() {
            _states = new List<IState>();
        }

        public FiniteStateMachine(IState initialState) : this()
        {
            CurrentState = initialState;
            _states.Add(initialState);
        }

        public void AddState(IState state) {
            _states.Add(state);
        }

        public void Update() {
            CurrentState?.Update();
        }

        public void FixedUpdate() {
            CurrentState?.FixedUpdate();
        }

        public void LateUpdate() {
            CurrentState?.LateUpdate();
        }

        public void SetInitialState(IState state)
        {
            if(CurrentState != null) return;
            CurrentState = state;
        }
        
        public void ChangeState(IState state)
        {
            if(state == CurrentState) return;
            
            CurrentState?.Exit();
            state.Enter();

            CurrentState = state;
        }
    }
}
