using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tutorial : MonoBehaviour, IPointerClickHandler
{
    private GameData _gameData;
    [SerializeField] private GameObject[] Panels;
    private int CurrentPanelIndex = 0;
    void Start()
    {
        _gameData = FindObjectOfType<GameData>();
        if (_gameData._isActiveTutorial)
        {
            Time.timeScale = 0;
            Panels[CurrentPanelIndex].SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        OpenNextPanel();
    }

    public void OpenNextPanel()
    {
        if (CurrentPanelIndex == Panels.Length - 1)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            _gameData.OffTutorial();
        }
        else
        {
            Panels[CurrentPanelIndex].SetActive(false);
            CurrentPanelIndex++;
            Panels[CurrentPanelIndex].SetActive(true);
        }
    }
}
