using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベースデータ
/// </summary>
[System.Serializable]
public class BaseComposition
{
    public uint CountField()
    {
        return (uint)this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Length;
    }

    public string GetVariableName(uint index)
    {
        var fields = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (fields == null) return "";
        if (index >= fields.Length) return "";

        return fields[index].Name;
    }

    public object GetValue(string search_data_name)
    {
        var fields = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (fields == null) return null;

        for (uint count = 0; count < CountField(); count++)
        {
            if (fields[count].Name == search_data_name)
            {
                return fields[count].GetValue(this);
            }
        }
        return null;
    }


    public void SetValue(string search_data_name, object value_object)
    {
        var fields = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (fields == null) return;

        for (uint count = 0; count < CountField(); count++)
        {
            if (fields[count].Name == search_data_name)
            {
                fields[count].SetValue(this, value_object);
                return;
            }
        }
    }
}
