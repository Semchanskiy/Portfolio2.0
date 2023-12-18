using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameData.Instance.PlayerInfo._level < SceneManager.GetActiveScene().buildIndex)
        {
            GameData.Instance.PlayerInfo._level = SceneManager.GetActiveScene().buildIndex;

#if !UNITY_EDITOR && UNITY_WEBGL
            GameData.Instance.Save();
#endif

        }
    }
}
