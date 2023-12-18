using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ChangeScenes", menuName = "Scene Data/Database")]
public class ScenesData : ScriptableObject
{
    /*
 	* Уровни
 	*/

    // Загружаем сцену с заданным индексом
    public void LoadLevelWithName(string str)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(str);
    }
    public void LoadLevelWithIndex(int _index)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_index);
    }

    // Запуск следующего уровня
    public void NextLevel()
    {
        Time.timeScale = 1.0f;

        LoadLevelWithIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Перезапускаем текущий уровень
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        LoadLevelWithIndex(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnOffTime()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}