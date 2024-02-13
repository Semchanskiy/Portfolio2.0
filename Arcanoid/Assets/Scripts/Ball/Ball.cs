using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public abstract class Ball : MonoBehaviour
{

    public GameObject debugSprite;
    public bool hitOnes = true;
    public float Speed;
    private float _startSpeedX;
    private float _startSpeedY;

    private float _currentSpeed = 0;
    private float _currentSpeedX;
    private float _currentSpeedY;

    [SerializeField] private float _accelerateSpeed; //0.005f
    private float _procX; // процент ежесекундного ускорени€ дл€ этой оси
    private float _procY; // процент ежесекундного ускорени€ дл€ этой оси

    [SerializeField] private float _lengthPlatform;

    [HideInInspector] public PlatformController _platform;

    private Rigidbody2D _rb;
    private BoxCollider2D _collider;

    private float _platformCenterPosition;
    private float _ballPositionY;
    private bool _isActiv;
    public int Damage = 1;

    [SerializeField] private LayerMask _containerLayer;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }


    protected virtual void Update()
    {


        hitOnes = true;
        CheckActivatedBall();
        if(_isActiv)
        {
            //_rb.AddForce(new Vector2(_procX * _rb.velocity.normalized.x, _procY * _rb.velocity.normalized.y) *_accelerateSpeed);
        }
    }

    protected virtual void FixedUpdate()
    {
        _currentSpeedX = _rb.velocity.x;
        _currentSpeedY = _rb.velocity.y;
        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);
        //CheckBlock();
    }

    protected virtual void CheckBlock()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, _collider.size / 2, 0f, new Vector2(_rb.velocity.x, _rb.velocity.y), 40, _containerLayer);
        Debug.Log(hit.centroid);
        Debug.DrawLine(transform.position, hit.centroid, Color.yellow);

        float dist = 0.3f;



        _ballPositionY = transform.position.y;
        if (_rb.velocity.y > 0)
        {


            ExtDebug.DrawBoxCastBox(transform.position, _collider.size / 2, Quaternion.identity, Vector2.up, dist, Color.green);
            ExtDebug.DrawBox(transform.position + new Vector3(0, dist, 0f), _collider.size / 2, Quaternion.identity, Color.red);
            if (Physics2D.BoxCast(transform.position, _collider.size / 2, 0f, Vector2.up, dist, _containerLayer))
            {
                Collider2D[] rightColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(0, dist, 0f), _collider.size, 0, _containerLayer);
                foreach (var collider in rightColliders)
                {
                    if (collider.TryGetComponent(out ContainerController container))
                    {
                        container.Punch(Damage);
                        _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
                        _currentSpeedX = _rb.velocity.x;
                        _currentSpeedY = _rb.velocity.y;
                        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);
                        break;
                    }
                }
            }
        }

        if (_rb.velocity.y < 0)
        {
            ExtDebug.DrawBox(transform.position + new Vector3(0, -dist, 0f), _collider.size / 2, Quaternion.identity, Color.red);
            ExtDebug.DrawBoxCastBox(transform.position, _collider.size / 2, Quaternion.identity, Vector2.down, dist, Color.green);
            if (Physics2D.BoxCast(transform.position, _collider.size / 2, 0f, Vector2.down, dist, _containerLayer))
            {
                Collider2D[] rightColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(0, -dist, 0f), _collider.size, 0, _containerLayer);
                foreach (var collider in rightColliders)
                {
                    if (collider.TryGetComponent(out ContainerController container))
                    {
                        container.Punch(Damage);
                        _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
                        _currentSpeedX = _rb.velocity.x;
                        _currentSpeedY = _rb.velocity.y;
                        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);
                        break;
                    }
                }
            }
        }

        if (_rb.velocity.x > 0)
        {
            ExtDebug.DrawBox(transform.position + new Vector3(dist, 0, 0f), _collider.size / 2, Quaternion.identity, Color.red);
            ExtDebug.DrawBoxCastBox(transform.position, _collider.size / 2, Quaternion.identity, Vector2.right, dist, Color.green);
            if (Physics2D.BoxCast(transform.position, _collider.size / 2, 0f, Vector2.right, dist, _containerLayer))
            {
                Collider2D[] rightColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(dist, 0f, 0f), _collider.size, 0, _containerLayer);
                foreach (var collider in rightColliders)
                {
                    if (collider.TryGetComponent(out ContainerController container))
                    {
                        container.Punch(Damage);
                        _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
                        _currentSpeedX = _rb.velocity.x;
                        _currentSpeedY = _rb.velocity.y;
                        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);
                        break;
                    }
                }
            }
        }

        if (_rb.velocity.x < 0)
        {
            ExtDebug.DrawBox(transform.position + new Vector3(-dist, 0, 0f), _collider.size / 2, Quaternion.identity, Color.red);
            ExtDebug.DrawBoxCastBox(transform.position, _collider.size / 2, Quaternion.identity, Vector2.left, dist, Color.green);
            if (Physics2D.BoxCast(transform.position, _collider.size / 2, 0f, Vector2.left, dist, _containerLayer))
            {
                Collider2D[] rightColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(-dist, 0f, 0f), _collider.size, 0, _containerLayer);
                foreach (var collider in rightColliders)
                {
                    if (collider.TryGetComponent(out ContainerController container))
                    {
                        container.Punch(Damage);
                        _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
                        _currentSpeedX = _rb.velocity.x;
                        _currentSpeedY = _rb.velocity.y;
                        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);
                        break;
                    }
                }
            }
        }
    }


    public void PunchOne(Vector2 position, int damage) // дл€ сомпозита и точек
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(position, 0.2f, _containerLayer);
        if (collider2Ds.Length > 0)
        {
            foreach (var collider in collider2Ds)
            {
                if (collider.TryGetComponent(out ContainerController container))
                {
                    Debug.Log("PunchOne");
                    container.Punch(damage);
                    break;
                }
                else
                {
                    Debug.Log(collider.gameObject.name);
                }
            }
        }
        else
        {
            Debug.Log(" оллайдеры не обнаружены");
        }
    } 
    public void PunchAll(Vector2 position, int damage)
    {
        List<Collider2D> collider2Ds = new List<Collider2D>();

        if (Physics2D.Raycast(position, Vector2.up, 0.4f, _containerLayer).collider != null)
        {
            collider2Ds.Add(Physics2D.Raycast(position, Vector2.up, 0.4f, _containerLayer).collider);
        }
        if (Physics2D.Raycast(position, Vector2.down, 0.4f, _containerLayer).collider != null)
        {
            collider2Ds.Add(Physics2D.Raycast(position, Vector2.down, 0.4f, _containerLayer).collider);
        }
        if (Physics2D.Raycast(position, Vector2.right, 0.4f, _containerLayer).collider != null)
        {
            collider2Ds.Add(Physics2D.Raycast(position, Vector2.right, 0.4f, _containerLayer).collider);
        }
        if (Physics2D.Raycast(position, Vector2.left, 0.4f, _containerLayer).collider != null)
        {
            collider2Ds.Add(Physics2D.Raycast(position, Vector2.left, 0.4f, _containerLayer).collider);
        }
        Debug.Log(collider2Ds.Count);

        if (collider2Ds.Count > 0)
        {

            foreach (var collider in collider2Ds)
            {
                if (collider.TryGetComponent(out ContainerController container))
                {
                    Debug.Log("PunchAll");
                    container.Punch(damage);
                }
                else
                {
                    Debug.Log(collider.gameObject.name);
                }
            }
        }
        else
        {
            Debug.Log(" оллайдеры не обнаружены");
        }
    } // дл€ сомпозита и точек
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        _ballPositionY = transform.position.y;


            if (collision.gameObject.TryGetComponent(out LostZone lostZone))
        {
            DeathBall();
        }

        if (collision.gameObject.TryGetComponent(out ContainerController container) && hitOnes)
        {
            float dist = 0.5f;
            RaycastHit2D collUp = Physics2D.Raycast(transform.position, Vector2.up, dist, _containerLayer);
            RaycastHit2D collDown = Physics2D.Raycast(transform.position, Vector2.down, dist, _containerLayer);
            RaycastHit2D collRight = Physics2D.Raycast(transform.position, Vector2.right, dist, _containerLayer);
            RaycastHit2D collLeft = Physics2D.Raycast(transform.position, Vector2.left, dist, _containerLayer);
            if ((collUp == true || collDown == true) && (collRight == true || collLeft == true))
            {
                container.Punch(Damage);
            }
            else
            {
                //if (collUp == true || collDown == true)
                //{
                //    if (_rb.velocity.x != _currentSpeedX)
                //    {
                //        _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
                //    }
                //}
                //else if (collRight == true || collLeft == true)
                //{
                //    if (_rb.velocity.y != _currentSpeedY)
                //    {
                //        _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
                //    }
                //}
                //if (_rb.velocity.x > 0)
                //{
                //    Debug.Log("SSS");
                //}
                //if (_currentSpeedX > 0)
                //{
                //    Debug.Log("ddd");
                //}
                container.Punch(Damage);
                hitOnes = false;
            }
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        _ballPositionY = transform.position.y;

        _currentSpeedX = _rb.velocity.x;
        _currentSpeedY = _rb.velocity.y;
        _currentSpeed = (float)Math.Sqrt(_currentSpeedX * _currentSpeedX + _currentSpeedY * _currentSpeedY);

        if (collision.gameObject.TryGetComponent(out PlatformController player)) // при соприкосновении с платформой
        {
            CalculationsBounceAtPlatform();
            StartMove(_currentSpeedX, _currentSpeedY); // даем направление м€чу

        }

       
    }

    #region Move
    private void CheckActivatedBall()
    {
        if (!_isActiv) // если м€ч не активен
        {
            if (Math.Abs(_platform.transform.position.y - transform.position.y) >=
                _lengthPlatform/2) // провер€ет разницу по оси Y между платформой и м€чом
            {
                //transform.position = new Vector2(transform.position.x, _platform.transform.position.y - transform.position.y); 
                if (_platform.transform.position.y - transform.position.y <=
                    -_lengthPlatform / 2) // ставит его возле верхнего кра€ платформы
                {
                    transform.position = new Vector2(transform.position.x, _platform.transform.position.y + _lengthPlatform / 2);
                }

                if (_platform.transform.position.y - transform.position.y >=
                    _lengthPlatform / 2) // ставит его возле нижнегоы кра€ платформы
                {
                    transform.position = new Vector2(transform.position.x, _platform.transform.position.y - _lengthPlatform / 2);
                }
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                BallActivete(); //вызвать метод активации м€ча
            }
        }
    }
    private void BallActivete() // метод активации м€ча
    {
        LevelManager.LevelController.Model._BallsInGame.Add(this);

        _isActiv = true;

        _ballPositionY = transform.position.y;
        _platformCenterPosition = _platform.gameObject.GetComponent<Transform>().position.y;
        float difference = (_ballPositionY - _platformCenterPosition);
        float differenceNormal = difference / ((_lengthPlatform) / 2); //при изменении размера платформы нужно мен€ть 0.5f
        if (Math.Abs(differenceNormal) > 0.7f)
        {
            if (differenceNormal > 0)
            {
                differenceNormal = 0.7f;
            }
            else
            {
                differenceNormal = -0.7f;
            }
        }

        _startSpeedX = (float)Math.Sqrt(1 * 1 - differenceNormal * differenceNormal) * Speed;
        _startSpeedY = differenceNormal * Speed;



        _procX = _startSpeedX / Speed;
        _procY = _startSpeedY / Speed;
        StartMove(_startSpeedX, _startSpeedY);
    }

    private void CalculationsBounceAtPlatform() // проводим расчеты отклонени€ от платформы
    {
        _ballPositionY = transform.position.y;
        _platformCenterPosition = _platform.gameObject.GetComponent<Transform>().position.y;

        float difference = (_ballPositionY - _platformCenterPosition);
        float differenceNormal = difference / ((_lengthPlatform) / 2); //при изменении размера платформы нужно мен€ть 0.5f

        if (Math.Abs(differenceNormal) > 0.7f)
        {
            if (differenceNormal > 0)
            {
                differenceNormal = 0.7f;
            }
            else
            {
                differenceNormal = -0.7f;
            }
        }

        float coefAcellerateSpeed = Speed/_currentSpeed;



        _currentSpeedY = differenceNormal * Speed / coefAcellerateSpeed;
        _currentSpeedX = (float)Math.Sqrt(_currentSpeed * _currentSpeed - _currentSpeedY * _currentSpeedY);


        _procX = _currentSpeedX / _currentSpeed;
        _procY = _currentSpeedY / _currentSpeed;
    }

    private void DeathBall()
    {
        LevelManager.LevelController.Model._BallsInGame.Remove(this);
        if (LevelManager.LevelController.Model._BallsInGame.Count <= 0)
        {
            LevelManager.LevelController.CheckEndTurn();
        }
        Destroy(gameObject); //могут возникнуть проблемы с тем что он уничтожаетс€ после
    }

    private void StartMove(float x, float y) // даем направление м€чу 
    {
        _rb.velocity = new Vector2(x, y);
    }

    #endregion
}
