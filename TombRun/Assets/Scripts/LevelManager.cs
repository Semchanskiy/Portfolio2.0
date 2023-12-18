using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private PlayerLogic Player;
    [SerializeField] private float _starsCount = 0;
    private UIStars _UIStars;
    private LevelUI _UILevel;
    private ExitDoor exitDoor;
    private MovingCamera Camera;
    
    
    void Start()
    {
        exitDoor = FindObjectOfType<ExitDoor>();
        Player = FindObjectOfType<PlayerLogic>();
        _UIStars = FindObjectOfType<UIStars>();
        _UILevel = FindObjectOfType<LevelUI>();
        Camera = FindObjectOfType<MovingCamera>();
    }

    public void AddStar()
    {
        _starsCount++;
        _UIStars.AddStar(_starsCount);

        if(_starsCount == 3)
        {
            exitDoor.OpenDoor();
        }
    }

    public void WinLevel()
    {
        Player.gameObject.SetActive(false);
        Camera.WinMoving();
        _UILevel.OpenWinPanel();
    }



    void Update()
    {
        
    }
}
