using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsTrap : MonoBehaviour
{
    
    void Awake()
    {
        InicializationGameCore();
    }
    private void InicializationGameCore()
    {
        GameCore.BALL = FindAnyObjectByType<BallPhysics>();
        GameCore.BAT = FindAnyObjectByType<Bat>();
        GameCore.YANDEX = FindAnyObjectByType<Yandex>();
    }
}
