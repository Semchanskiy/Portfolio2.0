using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.Windows;

public class PlatformController : MonoBehaviour
{

    [HideInInspector] public float _moveInputPlatform = 0;

    public PlatformModel Model;

    private PlayerInput _input;
    private Rigidbody2D _rb;

    private Ball _startBall;

    public LayerMask groundLayer;

    void Start()
    {
        Model = GetComponent<PlatformModel>();
        _rb = GetComponent<Rigidbody2D>();
        FindStartBall();
    }
    void Awake()
    {
        _input = new PlayerInput();
    }
    void Update()
    {
        VerticalMove();
    }

    void FixedUpdate()
    {
        
    }
    public void FindStartBall()
    {
        _startBall = FindObjectOfType<Ball>();
    }

    public void VerticalMove()
    {
        _moveInputPlatform = _input.Game.PlatformMove.ReadValue<float>();
        if (CheckGround())
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = new Vector2(0, _moveInputPlatform * Model._speed);
        }
    }

    private bool CheckGround()
    {
        Vector2 CheckVector;
        float dist = 2.6f;

        if (_moveInputPlatform > 0)
        {
            CheckVector = Vector2.up;
        }
        else if (_moveInputPlatform < 0)
        {
            CheckVector = Vector2.down;
        }
        else
        {
            return true;
        }

        //Ray ray = new Ray(transform.position, CheckVector);

        Debug.DrawRay(transform.position, CheckVector * dist);

        if (Physics2D.Raycast(transform.position, CheckVector, dist, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
}
