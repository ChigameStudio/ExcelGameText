using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コルーチンハンドル
/// </summary>
public  class CoroutineHandler : Singleton<CoroutineHandler>
{
    /// <summary>
    /// スタートコルーチン
    /// </summary>
    /// <param name="action"></param>
    public void StartManualCoroutin(IEnumerator action)
    {
        Instance?.StartCoroutine(action);
    }
}
