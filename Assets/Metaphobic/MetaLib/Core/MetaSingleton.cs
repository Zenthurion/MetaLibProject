using System.Data.SqlTypes;
using UnityEngine;

namespace MetaLib.Core
{
    public class MetaSingleton<T> : MetaBehaviour where T : MetaSingleton<T>
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