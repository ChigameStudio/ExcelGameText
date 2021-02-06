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
        base.OnInspectorGUI();
        ExcelScenarioText chara = target as ExcelScenarioText;


        EditorGUI.BeginChangeCheck();

        GUILayout.BeginVertical();
        GUILayout.Label("PATH");
        chara.ExcelLoadPath = GUILayout.TextField(chara.ExcelLoadPath);
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        GUILayout.Label("SHEET");
        chara.ExcelLoadSheetName = GUILayout.TextField(chara.ExcelLoadSheetName);
        GUILayout.EndVertical();

        

        if (GUILayout.Button("CREATE"))
        {
            chara.CreateManual();
            EditorUtility.SetDirty(chara);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("SAVE_JSON"))
        {
            ProjectSystem.ExcelJsonSystem<ScenarioText>.SaveJson(chara.GetListData(),
            "D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel",
            "GameText");
        }
        if (GUILayout.Button("LOAD_JSON"))
        {
            var list =  ProjectSystem.ExcelJsonSystem<ScenarioText>.LoadJsonEditor(chara.GetListData(),
            "Assets/Project/Data/Excel/GameText.json");
            chara.SetListData(list);
        }
        if(GUILayout.Button("CLEAR"))
        {
            chara.GetListData().Clear();
        }

        EditorUtility.SetDirty(chara); // Dirtyフラグを立てることで、Unity終了時に勝手に.assetに書き出す
    }
}
#endif
