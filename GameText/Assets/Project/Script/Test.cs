using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
using System;
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
        IComparable com = a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
