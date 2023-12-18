using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private PlayerMove Player;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }

    private void Move()
    {
        _rb.velocity = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y) * _speed;
    }
    
    void Update()
    {
        Move();
    }

    public void WinMoving()
    {
        _speed = 0;
        _rb.AddForce(new Vector3(0, 0, 80));
    }
}
