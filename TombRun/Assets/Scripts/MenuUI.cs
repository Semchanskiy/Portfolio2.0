using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    private void Start()
    {
        ShowCurrentPanel(0);
    }

    public void ShowCurrentPanel(int index)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(i == index)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
}
