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



}
