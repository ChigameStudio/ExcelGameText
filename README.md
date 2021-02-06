# ExcelGameText

# 用意するもの
![test excel](/Excel.png)
<p>こんな感じで、横一列に用意データの構造を作る(画像だと、今回は{ID,名前,テキスト,サブテキスト}となっております)</p>

<h2>NPOI を使っての自動Excelデータ読み取り</h2>
<p> BaseExcelScriptableObject<T> と　BaseComposition を継承したClassを作成します </p>
  ```
  public class ExcelHoge : BaseComposition
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

    public ExcelHoge()
    {
        name_ = "";
        text_ = "";
        sub_text_ = "";
    }
  }
  ```
