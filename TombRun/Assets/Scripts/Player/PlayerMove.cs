using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private AudioSource StepSound;


    public PlayerInput _input;
    private Animator _animator;
    private Rigidbody2D _rb;
    [SerializeField] private bool _isMoving = false;

    [SerializeField] private float _speed;

    void Awake()
    {
        _input = new PlayerInput(); // именно в awake
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        #region INPUT
        _input.Player.Up.performed += context => Move(new Vector2(0, 1));
        _input.Player.Down.performed += context => Move(new Vector2(0, -1));
        _input.Player.Right.performed += context => Move(new Vector2(1, 0));
        _input.Player.Left.performed += context => Move(new Vector2(-1, 0));
        #endregion
    }



    private void Move(Vector2 _vector)
    {
        if(!_isMoving)
        {
            
            _animator.SetBool("Moving", true);
            CorrectionRotationPlayer(_vector);
            CorrectionPositionPlayer();
            _isMoving = true;
            _rb.velocity = _vector*_speed;

        }
    }

    private void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            //_isMoving = false;
            CorrectionPositionPlayer();
            _rb.velocity = Vector2.zero;
            _animator.SetBool("Moving", false);
            StepSound.Play();
            //_input.Enable();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isMoving = false;
            _animator.SetBool("Moving", false);
        }
    }

    private void CorrectionRotationPlayer(Vector2 _vector)
    {
        if(_vector.x ==-1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if(_vector.x==1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (_vector.y== -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_vector.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    private void CorrectionPositionPlayer()
    {
        float _remainsX = transform.position.x % 0.5f;
        float _remainsY = transform.position.y % 0.5f;

        if (_remainsX > 0.25f && _remainsX < 0.5f)
        {
            transform.position = new Vector2(transform.position.x + (0.5f - _remainsX), transform.position.y);
        }
        else if (_remainsX > 0f && _remainsX < 0.25f)
        {
            transform.position = new Vector2(transform.position.x - _remainsX, transform.position.y);
        }
        else if (_remainsX > -0.25f && _remainsX < 0f)
        {
            transform.position = new Vector2(transform.position.x - _remainsX, transform.position.y);
        }
        else if (_remainsX > -0.5f && _remainsX < -0.25f)
        {
            transform.position = new Vector2(transform.position.x + (-0.5f - _remainsX), transform.position.y);
        }

        if (_remainsY > 0.25f && _remainsY < 0.5f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (0.5f - _remainsY));
        }
        else if (_remainsY > 0f && _remainsY < 0.25f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - _remainsY);
        }
        else if (_remainsY > -0.25f && _remainsY < 0f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - _remainsY);
        }
        else if (_remainsY > -0.5f && _remainsY < -0.25f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (-0.5f - _remainsY));
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
