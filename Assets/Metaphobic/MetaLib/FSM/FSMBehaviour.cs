using Sirenix.OdinInspector;
using UnityEngine;

namespace MetaLib.FSM
{
    public class FSMBehaviour : MonoBehaviour
    {
        protected IFiniteStateMachine FSM { get; private set; }

        [ShowInInspector]
        public string CurrentStateName => FSM?.CurrentState?.Name;

        protected virtual void Awake()
        {
            FSM = new FiniteStateMachine();
        }

        private void Start()
        {
            FSM.CurrentState?.Enter();
        }

        protected virtual void Update()
        {
            FSM.Update();
        }

        protected virtual void FixedUpdate()
        {
            FSM.FixedUpdate();
        }

        protected virtual void LateUpdate()
        {
            FSM.LateUpdate();
        }
    }
}