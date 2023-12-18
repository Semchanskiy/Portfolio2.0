using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextEnemyCount : MonoBehaviour
{
    public Text text;
    private TextEnemyCount2 _textEnemyCount2;
    void Start()
    {
            _textEnemyCount2 = FindObjectOfType<TextEnemyCount2>();
    }
    public void UpdateText(int count) 
    {
        text.text = "Enemies left: " + count;
        _textEnemyCount2.UpdateText(count);
    }
    
    void Update()
    {
        
    }
}
