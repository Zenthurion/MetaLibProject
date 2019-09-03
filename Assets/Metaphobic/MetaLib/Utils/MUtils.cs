using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace MetaLib.Utils
{
    public static class MUtils
    {
        public static IEnumerator WaitThenAct(float wait, Action action)
        {
            yield return new WaitForSeconds(wait);
            action();
        }

        public static string GetRandomString()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }

        public static T RaycastMouse<T>(Camera cam)
        {
            return RaycastMouse(cam, out var hit) ? 
                hit.transform.GetComponent<T>() : 
                default(T);
        }

        public static bool RaycastMouse(Camera cam, out RaycastHit hit)
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit);
        }
    }
}