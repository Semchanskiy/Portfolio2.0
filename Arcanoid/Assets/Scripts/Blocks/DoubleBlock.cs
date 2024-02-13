using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBlock : Block
{
    public override void ApplyDamage(int damage)
    {
        LevelManager.LevelController.ApplyDamage(LevelManager.LevelController.Model.accumulatedDamage * 2);
    }
}
