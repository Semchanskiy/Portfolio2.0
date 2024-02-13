using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speedMove;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PositionMove();
    }

    private void PositionMove()
    {

            Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _c = _mousePos - new Vector2(_rb.transform.position.x, _rb.transform.position.y);
            _rb.velocity = _c * _speedMove;
    }
}
