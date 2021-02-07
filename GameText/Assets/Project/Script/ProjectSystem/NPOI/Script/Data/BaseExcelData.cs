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
public static class CreateExcelData<T>  where T : BaseComposition,new()
{


    public static List<T> CreateAuto(string excel_load_path,string excel_load_sheet_name_) 
    {
        List<T> list_data_object_ = new List<T>();
        DataFrameControl<T> data_frame_control_ = new DataFrameControl<T>();
        Init(ref list_data_object_,ref data_frame_control_);
        return SetUp(LoadExcel(excel_load_path, excel_load_sheet_name_),ref list_data_object_,ref data_frame_control_);
    }

    public static List<T> CreateManual(string excel_load_path, string excel_load_sheet_name_)
    {
        List<T> list_data_object_ = new List<T>();
        DataFrameControl<T> data_frame_control_ = new DataFrameControl<T>();
        Init(ref list_data_object_, ref data_frame_control_);
        return SetUp(LoadExcel(excel_load_path, excel_load_sheet_name_), ref list_data_object_, ref data_frame_control_,true);
    }

    private static void  Init(ref List<T> list_data_object,ref DataFrameControl<T> data_frame_control) 
    {
        InitExcelConstructionControl(list_data_object,data_frame_control);
    }
    private static BaseComposition InitAdd(DataFrameGroup data_grop,ExcelSystem.DataGroup excel_data_group)
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

    private static BaseComposition InitAddManual(DataFrameGroup data_grop, ExcelSystem.DataGroup excel_data_group)
    {
        T data_object = new T();
        data_object.ManualSetUp(ref data_grop, ref excel_data_group);
        return data_object;
    }
    
    private static void InitExcelConstructionControl(List<T> list_data_object, DataFrameControl<T> data_frame_control)
    {
    }

    private static ExcelSystem.DataControl LoadExcel(string excel_load_path, string excel_load_sheet_name_)
    {
        return ExcelSystem.GetExcelLoadData(excel_load_path, excel_load_sheet_name_);
    }
    private static List<T> SetUp(ExcelSystem.DataControl data_control, ref List<T> list_data_object, ref DataFrameControl<T> data_frame_control,bool manual = false)
    {
        if (data_control == null) return null;



        for (uint count = 0; count < data_control.GetDataGroupCount; count++)
        {
            var data_group = data_control.GetDataGroupIndex(count);
            if (data_group == null) continue;
            var data_frame_group = data_frame_control.AddDataFrameGrop();
            T data_object;
            if (manual == false) data_object = (T)InitAdd(data_frame_group, data_group);
            else data_object = (T)InitAddManual(data_frame_group,data_group);
            for (uint data_count = 0; data_count < data_group.GetListDataCount; data_count++)
            {
                var data = data_group.GetData(data_count);
                if (data == null) continue;
                DataFrame data_frame = data_frame_group.GetSearchDataFrame(data.GetDataName);
                object com = data_frame.Data;
                data_control.CovertDataList(ref com, (int)count, data.GetDataName);
                data_frame.Data = com;
                data_object.SetValue(data_frame.VariableName,data_frame.Data);
            }
            list_data_object.Add(data_object);
        }
        data_control.Clear();
        data_frame_control.Clear();

        return list_data_object;
    }
}



#endif
