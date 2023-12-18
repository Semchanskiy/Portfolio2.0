using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private AudioSource WinSound;

    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite _openDoor;
    private bool _doorIsOpen = false;
    void Start()
    {
        WinSound = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _doorIsOpen == true)
        {
            levelManager.WinLevel();
            WinSound.Play();
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = _openDoor;
        _doorIsOpen = true;
    }
    
}
