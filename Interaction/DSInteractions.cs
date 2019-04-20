using System.Collections.Generic;
using DwarvenSoftware.Framework.Core;
using DwarvenSoftware.Framework.Utils;
using UnityEngine;

namespace DwarvenSoftware.Framework.Interaction
{
    public class DSInteractions : DSSingleton<DSInteractions>
    {
        public Camera RayCam;

        private void Start()
        {
            if(RayCam == null) RayCam = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) // Left Click
            {
                var hit = DSUtils.RaycastMouse<ISelectable>(RayCam);
                if (hit == null || !hit.IsSelectable) return;
                
                if(hit.IsSelected)
                    hit.Deselect();
                else
                    hit.Select();
            }
            else if (Input.GetMouseButtonDown(1)) // Right Click
            {
                
            }
        }
    }
}