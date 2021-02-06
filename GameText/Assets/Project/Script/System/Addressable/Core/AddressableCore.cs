using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AddressableCore
/// </summary>
public class AddressableCore
{
    /// <summary>
    /// クリエイト関数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AddressableObject<T> CreateAddressable<T>(string path) where T : Object,new()
    {
        return new AddressableObject<T>(path);
    }
}
