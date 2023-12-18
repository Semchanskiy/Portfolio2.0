using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "DeathIdolZone")
        {
            levelUI.OpenLosePanel();
        }
    }
}
