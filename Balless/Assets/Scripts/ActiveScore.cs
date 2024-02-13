using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveScore : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _startPointBall;
    public float _activeScore = 0;

    
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    private void UpdateScore()
    {
        _activeScore = ((GameCore.BALL.transform.position.x - _startPointBall.transform.position.x)/20);
        if (_activeScore < 0)
        {
            _activeScore = 0;
        }
        string str = _activeScore.ToString("0.0");
        _scoreText.text = str + " ì.";
    }
    void FixedUpdate()
    {
        UpdateScore();
    }


}
