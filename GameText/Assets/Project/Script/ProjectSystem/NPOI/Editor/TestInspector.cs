using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(ExcelScenarioText))]
public class TestInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ExcelScenarioText chara = target as ExcelScenarioText;
        if (GUILayout.Button("CREATE"))
        {
            chara.Create();
        }
        if(chara.GetScenario != null)
        {
            foreach(var obj in chara.GetScenario.GetListDataObject)
            {
                GUILayout.TextField("TEXT", "aaaa");
            }
        }
    }
}
#endif
