using System.Collections.Generic;

namespace DwarvenSoftware.Framework.FSM
{
    public class FiniteStateMachine : IFiniteStateMachine
    {
        private readonly List<IState> _states;
        
        public event StateChangeEvent OnStateChange;

        public FiniteStateMachine()
        {
            _states = new List<IState>();
        }

        public FiniteStateMachine(IState initialState) : this()
        {
            CurrentState = initialState;
            _states.Add(initialState);
        }

        public IState CurrentState { get; private set; }

        public void AddState(params IState[] state)
        {
            _states.AddRange(state);
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }

        public void LateUpdate()
        {
            CurrentState?.LateUpdate();
        }

        public void SetInitialState(IState state)
        {
            if (CurrentState != null) return;
            CurrentState = state;
        }

        public void ChangeState(IState state)
        {
            if (state == CurrentState) return;

            CurrentState?.Exit();
            state.Enter();
            OnStateChange?.Invoke(state, CurrentState);
            CurrentState = state;
        }
    }
}