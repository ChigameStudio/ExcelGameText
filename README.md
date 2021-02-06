# ExcelGameText

# 用意するもの
![test excel](/Excel.png)
<p>こんな感じで、横一列に用意データの構造を作る(画像だと、今回は{ID,名前,テキスト,サブテキスト}となっております)</p>

<h2>NPOI を使っての自動Excelデータ読み取り</h2>
<p> BaseExcelScriptableObject<T> と　BaseComposition を継承したClassを作成します </p>

```
[System.Serializable]
public class CompositionHoge : BaseComposition
{
    [SerializeField]
    private int id_ = 0;
    public ref int GeID()
    {
        return ref id_;
    }

    [SerializeField]
    private string name_ = "";
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

    public CompositionHoge()
    {
        name_ = "";
        text_ = "";
        sub_text_ = "";
    }
}

[CreateAssetMenu(fileName = "Hogege", menuName = "ScriptableObjects/ExcelHoge")]
 public class ExcelHoge : BaseExcelScriptableObject<CompositionHoge>
{

}
```



<p>このようなコードを作成します</p>
<p>CompositionHoge の説明しますと、上記の画像のエクセル画像のデータ表左から順に合わせて変数を作っております</p>
<p>いちおう、上から順番に作ればその通りに当てはまるように作成してます(*いちおう、このデータ名を指定したいというのもあると思い、自分から指定する方法も作ってます)</p>

     [CustomEditor(typeof(ExcelHoge))]
     public class HogeInspector : Editor
     {

      public override void OnInspectorGUI()
      {
        base.OnInspectorGUI();
        ExcelHoge chara = target as ExcelHoge;


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
            ProjectSystem.ExcelJsonSystem<CompositionHoge>.SaveJson(chara.GetListData(),
            "D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel",
            "GameText");
             AssetDatabase.Refresh();
        }
        if (GUILayout.Button("LOAD_JSON"))
        {
            var list = ProjectSystem.ExcelJsonSystem<CompositionHoge>.LoadJsonEditor(chara.GetListData(),
            "Assets/Project/Data/Excel/GameText.json");
            chara.SetListData(list);
        }
        if (GUILayout.Button("CLEAR"))
        {
            chara.GetListData().Clear();
        }

        EditorUtility.SetDirty(chara); // Dirtyフラグを立てることで、Unity終了時に勝手に.assetに書き出す
      }
    
     }
     
<p>これを作成すると、Inspectorはこんな感じになります</p>

![test excel](/Hoge_Data.png)

<p>右の項目で、PATHとSHHETとという文字を入れるところを入力してください</p>

![test excel](/Hoge_Data02.png)

<p>PATH は、参照するエクセルの絶対パス</p>
<p>SHEETは、参照するエクセルのシート名</p>
<p>list_data_object_に、順番通り代入されます</p>
<p>また、そこからJSON化したいとき、SAVE_JSONなどすれば、Json化されます</p>

```
         if (GUILayout.Button("SAVE_JSON"))
        {
            ProjectSystem.ExcelJsonSystem<CompositionHoge>.SaveJson(chara.GetListData(),
            "D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel",
            "GameText");
        }
```
<p>ExcelJsonSystemの第二引数は、保存したjsonの絶対パス、第三引数が保存したい名前</p>
