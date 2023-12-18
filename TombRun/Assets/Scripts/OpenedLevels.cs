using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenedLevels : MonoBehaviour
{
    [SerializeField] private Button[] buttons; 
    void Start()
    {
        OpenLevels();
    }
    private void OnEnable()
    {
        OpenLevels();
    }

    public void OpenLevels()
    {
        for (int i = 0, imax = GameData.Instance.PlayerInfo._level; i < imax; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
