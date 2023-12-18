using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo 
{
    public int _level;
}


public class GameData : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();

    
    public static GameData Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

#if !UNITY_EDITOR && UNITY_WEBGL
            LoadExtern();
#endif

        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
