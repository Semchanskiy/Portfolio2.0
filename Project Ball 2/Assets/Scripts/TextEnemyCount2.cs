using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextEnemyCount2 : MonoBehaviour
{
    public Text text;



    public void UpdateText(int count) 
    {
        text.text = "Enemies left: " + count;
        
    }
    
    void Update()
    {
        
    }
}
