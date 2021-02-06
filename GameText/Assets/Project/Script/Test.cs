using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
using System;

public class Test : MonoBehaviour
{
    
    public ListDataObject<ScenarioText> data_ = new ListDataObject<ScenarioText>();
    // Start is called before the first frame update
    void Start()
    {
        data_ = new ListDataObject<ScenarioText>();
        ExcelJsonSystem<ScenarioText>.LoadJson(ref data_,
            "Assets/Project/Data/Excel/GameText.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
