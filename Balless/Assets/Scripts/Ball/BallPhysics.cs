using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _collisions = 0;
    private float maxModSpeed = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float modSpeed = Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.y);
        //_rb.AddForce(new Vector2(0, -.5f));
        
        if (modSpeed >= maxModSpeed)
        {
        maxModSpeed = modSpeed;

        }

    
    }

    public void PlatformAddForce(Vector2 Force)
    {
        _rb.velocity = Force;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == GameCore.BAT.gameObject)
        {
            _collisions = 0;
            GameCore.BAT.TakeCollisionsCount(_collisions);
        }

        else
        {
            _collisions++;
            GameCore.BAT.TakeCollisionsCount(_collisions);
        }
    }


    public void DeathBall()
    {

        gameObject.SetActive(false);
    }

    public void StartBall()
    {
        gameObject.SetActive(true);
    }
}
