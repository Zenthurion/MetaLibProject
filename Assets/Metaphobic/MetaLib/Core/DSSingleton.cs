using System.Data.SqlTypes;
using UnityEngine;

namespace DwarvenSoftware.Framework.Core
{
    public class DSSingleton<T> : DSBehaviour where T : DSSingleton<T>
    {
        public static T Instance { get; set; }

        protected virtual void Awake() 
        {
            if (Instance != null)
            {
                Debug.LogWarning("An instance of " + typeof(T) + " already exists!");
                DestroyImmediate(this);
                return;
            }

            Instance = this as T;
        }
    }
}