using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System;

public enum SizeType
{
    OneOnOne, OneOnTwo, TwoOnTwo, OneOnThree
}
public enum Vulnerable
{
    Yes,No
}
public abstract class Block : MonoBehaviour
{
    protected AudioSource _punchSound;
    public SizeType sizeType;
    public Vulnerable vulnerable;
    public BlockType blockType;

    private string NameDestroyAnim;
    [HideInInspector] public ContainerController _container;

    [SerializeField] private int _lives;
    [HideInInspector] public BoxCollider2D _collider;

    private Animator _animator;
    private float _timeAnimDestroy = 0.3f;
    protected virtual void Awake()
    {
        _container = transform.parent.GetComponent<ContainerController>();
        _punchSound = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Start()
    {
        SetNameDestroyAnim();
    }

    protected virtual void SetNameDestroyAnim()
    {
        switch (sizeType)
        {
            case SizeType.OneOnOne:
                NameDestroyAnim = "Destroy1x1";
                break;
            case SizeType.OneOnTwo:
                NameDestroyAnim = "Destroy1x2";
                break;
            case SizeType.TwoOnTwo:
                NameDestroyAnim = "Destroy2x2";
                break;
            case SizeType.OneOnThree:
                NameDestroyAnim = "Destroy1x3";
                break;
        }
    }

    protected virtual void Update()
    {
        
    }
    public virtual void Punch(int damage)
    {
        _punchSound.Play();
        if (vulnerable == Vulnerable.Yes)
        {
            _lives--;
            if (_lives <= 0)
            {
                DestroyBlock(damage);
            }
        }
    }
    public virtual void DestroyBlock(int damage) //однозначно уничтожен
    {
        LevelManager.LevelController.Model._ContainersFilled.Remove(_container);
        LevelManager.LevelController.Model._ContainersNull.Add(_container);
        gameObject.transform.parent = null;
        _container._collider.enabled = false;
        _container._MyComposite.enabled = false;
        

        ApplyDamage(damage);
        _animator.speed = 1 / _timeAnimDestroy;
        _animator.CrossFade(NameDestroyAnim,0);
        WaitingDestroyAnimation(_timeAnimDestroy);
        
    }

    public virtual void ApplyDamage(int damage)
    {
        LevelManager.LevelController.ApplyDamage(damage);
    }
    public virtual void DeleteInGame()
    {
        Destroy(gameObject);
    }

    #region WaitEndAnim

    private async void WaitingDestroyAnimation(float time)
    {
        await WaitDestroyAnimation(time);
    }
    private async Task WaitDestroyAnimation(float time)
    {
        await Task.Delay(TimeSpan.FromSeconds(time));
        _animator.speed = 1;
        DeleteInGame();
    }
    #endregion


}
