using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAddInternal();


    public void ShowAdd()
    {

        ShowAddInternal();

    }

    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        ShowAdd();
        #endif
    }
}
