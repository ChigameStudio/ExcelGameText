using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
using System;
#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// Excelデータ(基礎)
/// </summary>
public class BaseExcelData<T>  where T : BaseComposition,new()
{
    /// <summary>
    /// Excelのパス
    /// </summary>
    protected string excel_load_path_ = "D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel/Book1.xlsx";
    /// <summary>
    /// Excelの参照Sheet名
    /// </summary>
    protected string excel_load_sheet_name_ = "Sheet1";

    [SerializeField]
    protected List<T> list_data_object_ = new List<T>();
    public List<T> GetListDataObject
    {
        get { return list_data_object_; }
    }
    protected DataFrameControl<ScenarioText> data_scenario_;

    public virtual void Create() 
    {
        Init();
        SetUp(LoadExcel());
    }
    
    protected void  Init() 
    {
        InitExcelConstructionControl();
    }
    protected virtual BaseComposition InitAdd(DataFrameGroup data_grop,ExcelSystem.DataGroup excel_data_group)
    {
        T data_object = new T();
        for(uint count = 0; count < excel_data_group.GetListDataCount; count++)
        {
            string variable_name = data_object.GetVariableName(count);
            if (variable_name == "") continue;

            data_grop.AddData(excel_data_group.GetData(count).GetDataName, variable_name, data_object.GetValue(variable_name));
        }
        return data_object;
    }
    protected void InitExcelConstructionControl()
    {
        data_scenario_ = new DataFrameControl<ScenarioText>();
        list_data_object_ = new List<T>();
    }

    protected virtual ExcelSystem.DataControl LoadExcel()
    {
        return ExcelSystem.GetExcelLoadData(excel_load_path_, excel_load_sheet_name_);
    }
    protected virtual void SetUp(ExcelSystem.DataControl data_control)
    {
        if (data_control == null) return;



        for (uint count = 0; count < data_control.GetDataGroupCount; count++)
        {
            var data_group = data_control.GetDataGroupIndex(count);
            if (data_group == null) continue;
            var data_frame_group = data_scenario_.AddDataFrameGrop();
            T data_object = (T)InitAdd(data_frame_group, data_group);
            for (uint data_count = 0; data_count < data_group.GetListDataCount; data_count++)
            {
                var data = data_group.GetData(data_count);
                if (data == null) continue;
                DataFrame data_frame = data_frame_group.GetSearchDataFrame(data.GetDataName);
                IComparable com = (IComparable)data_frame.Data;
                data_control.CovertDataList(ref com, (int)count, data.GetDataName);
                data_frame.Data = com;
                data_object.SetValue(data_frame.VariableName,data_frame.Data);
            }
            list_data_object_.Add(data_object);
        }
        data_control.Clear();
        data_scenario_.Clear();
    }
}



#endif
