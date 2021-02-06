using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace ProjectSystem
{
    /// <summary>
    /// ExcelでのデータをJsonシステム
    /// </summary>
    public static class ExcelJsonSystem<T>where T : BaseComposition
    {
        public static void SaveJson(List<T> composition,string save_path,string save_name)
        {
            var json = JsonUtility.ToJson(new Serialization<T>(composition));
            File.WriteAllText(save_path + "/" + save_name + ".json", json);
        }

        public static List<T> LoadJson(List<T> composition, string load_path)
        {
            string str = AssetDatabase.LoadAssetAtPath<TextAsset>(load_path).ToString();
            return JsonUtility.FromJson<Serialization<T>>(str).ToList();
        }

    }
}
#endif
