using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSystem;
using System;

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
        object t = test.GetType().GetField(test.ToString()).GetValue(test);
        Change(id, ref t);
        Enum.TryParse(t.ToString(),out test);


    }

    private void Change(object value_enum,ref object test_enum)
    {
        if (value_enum.GetType() == typeof(int))
        {
            string  change_enum = test.GetType().GetEnumName(value_enum);
            test_enum = change_enum;
        }
        else
        {
            foreach (var en in test.GetType().GetEnumValues())
            {
                if(en.ToString() == value_enum.ToString())
                {
                    test_enum = en;
                    return;
                }
            }
        }
       
    }
}
