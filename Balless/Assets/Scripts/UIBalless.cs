using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBalless : MonoBehaviour
{

    private AudioSource _endGame;


    public void PlaySound()
    {
        _endGame.Play();
    }

    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Window;
    [SerializeField] private InputBat _input;
    public GameObject[] panels;
    public int panelIndex;

    void ShowCurrentPanel()
    {
        for( int i=0; i< panels.Length; i++)
        {
            if (i == panelIndex)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
        
    }
    public void Awake()
    {
        _input = new InputBat();
    }

    public void SetPageIndex(int index)
    {
        panelIndex = index;
        ShowCurrentPanel();
    }

    void Start()
    {
        _input.UI.UIisActive.performed += context => EnableDisableUI(3);
        _endGame = GetComponent<AudioSource>();
    }




    public void EnableDisableUI(int index)
    {
        if(UI.activeSelf == true)
        {
            UI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            UI.SetActive(true);
            SetPageIndex(index);
            Time.timeScale = 0;
        }
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
