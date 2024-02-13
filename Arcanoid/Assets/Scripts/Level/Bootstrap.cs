using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private LevelManager _levelManager;

    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {
        _levelManager.FindStaticObjects();
        LevelManager.LevelController.Initialization();
    }

    void Update()
    {
        
    }
}
