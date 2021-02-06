using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リストデータ
/// </summary>
/// <typeparam name="T"></typeparam>
[System.Serializable]
public class ListDataObject<T> where T : BaseComposition,new ()
{
    [SerializeField]
    private List<T> list_data_object_ = new List<T>();
    public List<T> GetListDataObject()
    {
        return list_data_object_;
    }
    public void SetListDataObject(List<T> value_list)
    {
        list_data_object_ = value_list;
    }

    public void SetUp()
    {
        list_data_object_ = new List<T>();
    }
}
