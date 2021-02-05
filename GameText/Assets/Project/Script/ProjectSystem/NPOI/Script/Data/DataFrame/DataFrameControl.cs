using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データフレームコントロール
/// </summary>
public class DataFrameControl<T> where T : BaseComposition
{
    List<DataFrameGroup> list_data_frame_group_ = new List<DataFrameGroup>();
 
    List<T> list_data_composition_ = new List<T>();
    public List<T> GetListDataComposition
    {
        get { return list_data_composition_; }
    }

    public void SetUp()
    {
        list_data_composition_ = new List<T>();
        list_data_frame_group_ = new List<DataFrameGroup>();
    }

    public void Clear()
    {
        list_data_composition_.Clear();
        list_data_frame_group_.Clear();
    }

    public DataFrameGroup AddDataFrameGrop()
    {
        DataFrameGroup data_frame_grop = new DataFrameGroup();
        data_frame_grop.SetUp();
        list_data_frame_group_.Add(data_frame_grop);

     
        return data_frame_grop;
    }





    public void ValuData(uint search_data_group_index, string search_data_name,object value_data)
    {
        var data_group = GetDataFrameGroupIndex(search_data_group_index);
        if (data_group == null) return;

        data_group.ValueData(search_data_name, value_data);
    }

    public DataFrameGroup GetDataFrameGroupIndex(uint index)
    {
        if (list_data_frame_group_.Count == 0) return null;
        if (index >= list_data_frame_group_.Count) return null;

        return list_data_frame_group_[(int)index];
    }
}
