using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データ
/// </summary>
public class DataFrame
{
    private string data_name_;
    public string DataName
    {
        get { return data_name_; }
    }

    private string variable_name_;
    public string VariableName
    {
        get { return variable_name_; }
    }


    private object data_;
    public object Data
    {
        set { data_ = value; }
        get { return data_; }
    }

    public void SetUp(string value_data_name, string value_variable_name,object value_data)
    {
        data_name_ = value_data_name;
        variable_name_ = value_variable_name;
        data_ = value_data;
    }
}
