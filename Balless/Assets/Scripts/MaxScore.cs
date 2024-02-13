using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{

    private TextMeshProUGUI _scoreText;

    void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>(); 
    }

    public void UpdateMaxScore(float _newMaxScore)
    {

        if (Progress.Instance.PlayerInfo._maxScore <= _newMaxScore)
        {

            string str = _newMaxScore.ToString("0.0");

            _scoreText.text = "–екорд: " + str + " м.";

            Progress.Instance.PlayerInfo._maxScore = _newMaxScore;

        }

        
        
    }
}
