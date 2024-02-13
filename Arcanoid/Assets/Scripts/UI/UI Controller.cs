using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI accumulatedDamage;

    public void ChangeAccumulatedDamage(int newDamage)
    {
        accumulatedDamage.text = "Damage: " + newDamage;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
