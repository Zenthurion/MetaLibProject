﻿using MetaLib.FSM;
using UnityEngine;

namespace MetaLib.Tasks.Examples
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TimedTask : FSMBehaviour
    {
        private SimpleState _blue;
        private SimpleState _green;

        private SimpleState _red;
        private Renderer _renderer;

        public string current = "";

        private MTaskStack _tasks;

        protected override void Awake()
        {
            base.Awake();
            _renderer = GetComponent<MeshRenderer>();

            _tasks = new MTaskStack();

            _red = new SimpleState(FSM, "red");
            _green = new SimpleState(FSM, "green");
            _blue = new SimpleState(FSM, "blue");

            FSM.SetInitialState(_red);

            _red.OnEnter += state =>
            {
                _renderer.sharedMaterial.color = Color.red;
                current = "red";
            };
            _red.OnUpdate += state => { transform.Rotate(0, 45 * Time.deltaTime, 0); };

            _green.OnEnter += state =>
            {
                _renderer.sharedMaterial.color = Color.green;
                current = "green";
            };
            _green.OnUpdate += state => { transform.Rotate(45 * Time.deltaTime, 0, 0); };

            _blue.OnEnter += state =>
            {
                _renderer.sharedMaterial.color = Color.blue;
                current = "blue";
            };
            _blue.OnUpdate += state => { transform.Rotate(0, 0, 45 * Time.deltaTime); };
        }

        protected override void Update()
        {
            base.Update();
            _tasks.Evaluate();
        }

        private bool IsClicked()
        {
            if (!Input.GetMouseButtonDown(0)) return false;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100)) return hit.collider.transform == transform;

            return false;
        }

        private void OnMouseDown()
        {
            if (FSM.CurrentState == _red)
            {
                FSM.ChangeState(_green);
                Debug.Log("Green");
                var task = new MTimerTask((t) => t is MTimerTask tt && tt.Timer.Elapsed > 2);
                task.OnComplete += () => FSM.ChangeState(_blue);
                task.Timer.Start();
                _tasks.PushQueue(task);
            }
            else if (FSM.CurrentState == _green)
            {
                FSM.ChangeState(_blue);
                Debug.Log("Blue");
            }
            else
            {
                FSM.ChangeState(_red);
                Debug.Log("Red");
            }
        }
    
    }
}
