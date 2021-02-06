using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[System.Serializable]
public class BaseExcelScriptableObject<T> : ScriptableObject where T : BaseComposition,new()
{
    [SerializeField]
    protected ListDataObject<T> lis_data_object_ = new ListDataObject<T>();
    public List<T> GetListData()
    {
        return lis_data_object_.GetListDataObject();
    }
    public void SetListData(List<T> value_list_data)
    {
        lis_data_object_.SetListDataObject(value_list_data);
    }

    [SerializeField]
    protected string excel_load_path_ = "";
    public string ExcelLoadPath
    {
        set { excel_load_path_ = value; }
        get { return excel_load_path_; }
    }
    [SerializeField]
    protected string excel_load_sheet_name_ = "";
    public string ExcelLoadSheetName
    {
        set { excel_load_sheet_name_ = value; }
        get { return excel_load_sheet_name_; }
    }

    public BaseExcelScriptableObject()
    {

    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected void Init()
    {
        lis_data_object_ = new ListDataObject<T>();
        lis_data_object_.SetUp();
    }
    public void Create()
    {
        Init();
        lis_data_object_.SetListDataObject(CreateExcelData<T>.CreateAuto(excel_load_path_, excel_load_sheet_name_));
    }

    public void CreateManual()
    {
        Init();
        lis_data_object_.SetListDataObject(CreateExcelData<T>.CreateManual(excel_load_path_, excel_load_sheet_name_));
    }
}
#endif