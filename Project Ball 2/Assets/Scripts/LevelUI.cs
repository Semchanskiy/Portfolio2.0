using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private  GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    public void OpenLosePanel()
    {
        GetComponent<Animator>().SetBool("Enable", true);
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OpenWinPanel()
    {
        GetComponent<Animator>().SetBool("Enable", true);
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OpenPausePanel()
    {
        GetComponent<Animator>().SetBool("Enable", true);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AllPanelSetActiveFalse()
    {
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseAllPanel()
    {
        GetComponent<Animator>().SetBool("Enable", false);
    }
    
}
