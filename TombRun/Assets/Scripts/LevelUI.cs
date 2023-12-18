using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    [SerializeField] private PlayerInput _input;

    
    public void EnableOrDisablePause()
    {
        if(pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void OpenLosePanel()
    {
        losePanel.SetActive(true);
    }
    public void OpenWinPanel() 
    {
        winPanel.SetActive(true);
    }

    public void Awake()
    {
        _input = new PlayerInput();
    }

    void Start()
    {
        _input.UI.OpenPause.performed += context => EnableOrDisablePause();
    }

    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }
}
