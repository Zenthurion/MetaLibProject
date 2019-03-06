using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace DwarvenSoftware.Utils
{
    public static class DSUtils
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
    }
}