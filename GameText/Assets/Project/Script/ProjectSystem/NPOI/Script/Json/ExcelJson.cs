using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ProjectSystem
{
    /// <summary>
    /// ExcelでのデータをJsonシステム
    /// </summary>
    public  class ExcelJsonSystem<T> where T : BaseComposition,new()
    {
        public static void SaveJson(List<T> composition, string save_path, string save_name)
        {
            var json = JsonUtility.ToJson(new Serialization<T>(composition));
            File.WriteAllText(save_path + "/" + save_name + ".json", json);
        }
#if UNITY_EDITOR
        public static List<T> LoadJsonEditor(List<T> composition, string load_path)
        {
            string str = AssetDatabase.LoadAssetAtPath<TextAsset>(load_path).ToString();
            return JsonUtility.FromJson<Serialization<T>>(str).ToList();
        }
#endif
        public static void LoadJson(ref ListDataObject<T> listData, string load_path)
        {
            var obj = AddressableCore.CreateAddressable<TextAsset>(load_path);

            ExcelJsonSystem<T> excel_json = new ExcelJsonSystem<T>();
            CoroutineHandler.Instance.StartManualCoroutin(excel_json.LoadJsonCoroutin(listData, obj));
        }
        private  IEnumerator LoadJsonCoroutin(ListDataObject<T> listData, AddressableObject<TextAsset> addressable)
        {
            addressable.LoadStart();

            while(addressable.IsSetUp == false)
            {
                yield return null;
            }
            string str = addressable.GetObject.ToString();
            listData.SetListDataObject( JsonUtility.FromJson<Serialization<T>>(str).ToList());

            addressable.Release();

            yield break;
        }
    }
}

