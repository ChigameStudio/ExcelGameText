using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
/// <summary>
/// シナリオテキスト
/// </summary>
[System.Serializable]
public class ScenarioText : BaseComposition
{
    public enum type
    {
        bulter,
        yu,
        driver
    }

    [SerializeField]
    private int id_ = 0;
    public ref int GeID()
    {
        return ref id_;
    }

    [SerializeField]
    private type name_ = type.yu;
    public ref type GetName()
    {
       return ref name_; 
    }

    [SerializeField]
    private string text_ = "";
    public ref string GetText()
    {
        return ref text_;
    }


    public ScenarioText()
    {
        name_ = type.yu;
        text_ = "";
    }


    public override void ManualSetUp(ref DataFrameGroup data_grop, ref ProjectSystem.ExcelSystem.DataGroup excel_data_group)
    {
        data_grop.AddData("id", nameof(id_),id_);
        data_grop.AddData("発言者", nameof(name_), name_);
        data_grop.AddData("sentence", nameof(text_), text_);
    }

}
