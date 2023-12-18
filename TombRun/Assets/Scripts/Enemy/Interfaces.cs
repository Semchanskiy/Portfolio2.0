using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IMoveble
{
    void Move();
}

public interface IDamageble
{
    void OnCollisionEnter2D(Collision2D collision);
    
}

public interface IAttacker
{

}

