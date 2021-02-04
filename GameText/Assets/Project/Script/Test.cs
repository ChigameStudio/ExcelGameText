using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
public class Test : MonoBehaviour
{

    [SerializeField]
    private int a = 0;

    [SerializeField]
    private string hh = "";
    // Start is called before the first frame update
    void Start()
    {
        var data = ExcelSystem.GetExcelLoadData("D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel/Book1.xlsx", "Sheet1");
        data.CovertDataList(ref a, 0, "AS");
        data.CovertDataList(ref hh, 0, "DD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
