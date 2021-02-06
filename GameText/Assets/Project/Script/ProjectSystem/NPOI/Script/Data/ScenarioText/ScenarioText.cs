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
    [SerializeField]
    private int id_ = 0;
    public ref int GeID()
    {
        return ref id_;
    }

    [SerializeField]
    private string name_ = "D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel/Book1.xlsx";
    public ref string GetName()
    {
       return ref name_; 
    }

    [SerializeField]
    private string text_ = "";
    public ref string GetText()
    {
        return ref text_;
    }

    [SerializeField]
    private string sub_text_ = "";
    public ref string GetSubText()
    {
        return ref sub_text_;
    }

    public ScenarioText()
    {
        name_ = "";
        text_ = "";
        sub_text_ = "";
    }

    public override void ManualSetUp(ref DataFrameGroup data_grop, ref ProjectSystem.ExcelSystem.DataGroup excel_data_group)
    {
        data_grop.AddData("ID",nameof(id_),id_);
        data_grop.AddData("テキスト", nameof(name_), name_);
        data_grop.AddData("名前", nameof(text_), text_);
        data_grop.AddData("サブテキスト", nameof(sub_text_), sub_text_);
    }

}
