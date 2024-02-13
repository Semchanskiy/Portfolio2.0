using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelController LevelController;
    public static CompositeBlock CompositeBlock;
    public static UIController UIController;
    public void FindStaticObjects()
    {
        LevelController = FindObjectOfType<LevelController>();
        CompositeBlock = FindObjectOfType<CompositeBlock>();
        UIController = FindObjectOfType<UIController>();
    }
}
