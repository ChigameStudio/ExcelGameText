using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
using System;
using System.IO;

public class Test : MonoBehaviour
{
    
    public ListDataObject<ScenarioText> data_ = new ListDataObject<ScenarioText>();

    [System.Serializable]
    public enum TestInt : int 
    {
        kInit = 0,
        kMax
    }

    [SerializeField]
    private TestInt test = TestInt.kInit;

    private int id = 1;
    private string text = "kMax";

    private bool is_save_ = false;
    
    // Start is called before the first frame update
    void Start()
    {
        data_ = new ListDataObject<ScenarioText>();
        ExcelJsonSystem<ScenarioText>.LoadJson(ref data_,
            "Assets/Project/Data/Excel/GameText.json");
    }

    private void Update()
    {
        byte[] test_byte = System.Text.Encoding.UTF8.GetBytes(text);
        Debug.Log(test_byte.Length);

        if (is_save_ == true) return;

        FileStream fs = new FileStream("D:/Desk/Git/Git_GameText/GameText/GameText/Assets/Project/Data/Excel/Test.bin", FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(id);
        bw.Write(test_byte.Length);
        bw.Write(test_byte);

        bw.Close();
        fs.Close();
        is_save_ = true;
    }
}
