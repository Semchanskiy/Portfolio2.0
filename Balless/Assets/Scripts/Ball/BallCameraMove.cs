using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private Vector2 _napr;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(GameCore.BALL.transform.position.x, GameCore.BALL.transform.position.y,-10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(GameCore.BALL.transform.position.x - transform.position.x, GameCore.BALL.transform.position.y - transform.position.y) * _speed;
    }
}
