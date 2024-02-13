using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _startPointBall;
    [SerializeField] private GameObject _startPointBat;
    public void RestartGame()
    {
        GameCore.BALL.transform.position = _startPointBall.transform.position;
        GameCore.BALL.StartBall();
        _camera.transform.position = new Vector3(_startPointBall.transform.position.x, _startPointBall.transform.position.y,-10);
        GameCore.BAT.gameObject.GetComponent<BatMove>()._isHand= false;
        GameCore.BAT.gameObject.GetComponent<BatMove>()._textTakeBat.SetActive(true);
        GameCore.BAT.transform.position = _startPointBat.transform.position;

    }

    void Start()
    {
        
        Time.timeScale = 0;
    }
}
