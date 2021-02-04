#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class CopyAbsolutePath : MonoBehaviour
{

    [MenuItem("Assets/絶対パスをクリップボードにコピー", false)]
    static void Execute()
    {
        // get select GO full path
        int instanceID = Selection.activeInstanceID;
        string path = AssetDatabase.GetAssetPath(instanceID);
        string fullPath = System.IO.Path.GetFullPath(path);


        // copy clipboard
        GUIUtility.systemCopyBuffer = fullPath;
        Debug.Log("Copy clipboard : \n" + fullPath);
    }
}
#endif