using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public float _maxScore;
}
public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [SerializeField] MaxScore _classMaxScore;

    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();




    public static Progress Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _classMaxScore.UpdateMaxScore(PlayerInfo._maxScore);
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _classMaxScore.UpdateMaxScore(PlayerInfo._maxScore);
    }


}
