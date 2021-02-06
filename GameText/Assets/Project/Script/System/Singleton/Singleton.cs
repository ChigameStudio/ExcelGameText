using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シングルトン
/// </summary>
public abstract  class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance_ = null;
    public static T Instance
    {
        get
        {
            if (instance_ == null)
            {
                var obj = new GameObject();
                obj.name = nameof(T);
                DontDestroyOnLoad(obj);
                instance_ =  obj.AddComponent<T>();
            }
            return instance_;

        }
    }
}
