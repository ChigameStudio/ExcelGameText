using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データフレームグループ
/// </summary>
public class DataFrameGroup
{
    List<DataFrame> list_data_fraem_ = new List<DataFrame>();

    public void SetUp()
    {
        list_data_fraem_ = new List<DataFrame>();
    }

    public void AddData(string value_data_name,string value_variable_name, object value_data_object)
    {
        DataFrame data = new DataFrame();

       
        data.SetUp(value_data_name, value_variable_name, value_data_object);

        list_data_fraem_.Add(data);
    }

    public void Clear() => list_data_fraem_.Clear();

    public void ValueData(string search_data_frame_name, object value_data)
    {
        var data_frame = GetSearchDataFrame(search_data_frame_name);
        if (data_frame == null) return;
        data_frame.Data = value_data;
    }

    public DataFrame GetSearchDataFrame(string search_data_frame_name)
    {
        if (list_data_fraem_.Count == 0) return null;
        return list_data_fraem_.Find(data => data.DataName == search_data_frame_name);
    }
}
