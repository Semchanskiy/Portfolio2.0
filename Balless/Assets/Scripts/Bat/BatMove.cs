using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _maxSpeedMove;
    public bool _isHand;

    private Vector2 _rotateInput;
    private InputBat _input;
    public GameObject _textTakeBat;

    private void Awake()
    {
        _input = new InputBat();
    }

    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        
        _rotateInput = _input.Platforma.Rotate.ReadValue<Vector2>();

        RotateMove();
        PositionMove();
    }

    private void PositionMove()
    {
        if(_isHand == true)
        {
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _c = _mousePos - new Vector2(_rb.transform.position.x, _rb.transform.position.y);
        _rb.velocity = _c * _speedMove;
        
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }
    private void RotateMove()
    {
        if (_rotateInput.x != 0)
        {
            _rb.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - _rotateInput.x * _speedRotation) * Time.deltaTime);
        }
    }
    private void OnEnable()
    {

    }

    void OnMouseDown()
    {
        _input.Enable();
        _isHand = true;
        _textTakeBat.SetActive(false);

    }


    private void OnDisable()
    {
        _input.Disable();
    }
}
