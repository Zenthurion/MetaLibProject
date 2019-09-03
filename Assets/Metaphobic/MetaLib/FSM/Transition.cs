using System;

namespace DwarvenSoftware.Framework.FSM
{
    public class Transition : ITransition
    {
        private readonly IFiniteStateMachine _owner;
        private readonly IState _target;
        private readonly Func<bool> _condition;

        public Transition(IFiniteStateMachine owner, IState target, Func<bool> condition)
        {
            _owner = owner;
            _target = target;
            _condition = condition;
        }

        public bool Evaluate()
        {
            return _condition();
        }

        public void Execute()
        {
            _owner.ChangeState(_target);
        }
    }
}