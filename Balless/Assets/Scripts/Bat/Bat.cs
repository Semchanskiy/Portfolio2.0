using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider2D;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _soundPunch;

    [SerializeField] private float _cooldown;
    [SerializeField] private float _power;

    private Vector2 _force;

    [SerializeField] private bool _isActive = true;
    [SerializeField] private float _minCollisions;
    private bool _timeCollision = false;
    private float _collisions;

    void Start()
    {
        _soundPunch = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }


    # region CheckActive
    public void TakeCollisionsCount(float _col)
    {
        _collisions = _col;
        CheckActive();
    }

    private void CheckActive()
    {
        if(!_isActive && _collisions>=_minCollisions && _timeCollision)
        {
            ActivatedBat();
        }
    }

    IEnumerator AddForce(Vector2 Force)
    {
        yield return new WaitForFixedUpdate();
        GameCore.BALL.PlatformAddForce(Force);

    }
    IEnumerator EnablePlatform()
    {
        yield return new WaitForSeconds(_cooldown);
        _timeCollision = true;
        CheckActive();
    }

    public void ActivatedBat()
    {
        _polygonCollider2D.enabled = true;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.b, _spriteRenderer.color.g, 1f);
        _isActive = !_isActive;
    }
    private void DisActivatedPlatform()
    {
        _isActive = !_isActive;
        _timeCollision = false;
        _polygonCollider2D.enabled = false;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.b, _spriteRenderer.color.g, 0.2f);
        StartCoroutine(EnablePlatform());
        _force = GameCore.BALL.GetComponent<Rigidbody2D>().velocity * _power;
        StartCoroutine(AddForce(_force));
    }
#endregion CheckActive

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameCore.BALL.gameObject)
        {
            DisActivatedPlatform();
            _soundPunch.pitch = Random.Range(0.9f, 1.1f);
            _soundPunch.Play();
        }
        
    }

}
