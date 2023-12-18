using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    
    [SerializeField] private AudioSource DeathSound;


    private BoxCollider2D _collider;
    private Rigidbody2D _rb;
    private LevelUI _levelUI;
    private Animator _animator;
    private PlayerMove _playerMove;

    public void Death()
    {
        _collider.enabled = false;
        _animator.SetBool("Death", true);
        _rb.bodyType = RigidbodyType2D.Static;
        _playerMove._input.Disable();
        DeathSound.Play();
    }

    public void OpenLosePanel()
    {
        _levelUI.OpenLosePanel();
        gameObject.SetActive(false);
    }

    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _levelUI  = FindObjectOfType<LevelUI>();
        _collider = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        
    }
}
