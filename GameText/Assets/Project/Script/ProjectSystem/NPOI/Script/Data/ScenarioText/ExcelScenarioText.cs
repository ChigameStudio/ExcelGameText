using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateEnemyParamAsset")]
public class ExcelScenarioText : ScriptableObject
{
    [SerializeField]
    private BaseExcelData<ScenarioText> scenario_text_ = new BaseExcelData<ScenarioText>();
    public BaseExcelData<ScenarioText> GetScenario
    {
        get { return scenario_text_; }
    }

    public void Init()
    {

    }

    public void Create()
    {
        Init();
        scenario_text_.Create();
    }
}
#endif