using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private LevelManager levelManager;
    private float _animTimer = 4f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
        animator.Play("Shine_Star");
        StartCoroutine(AnimTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelManager.AddStar();
            gameObject.SetActive(false); // должно быть проигрывание анимации и последующее удаление объекта
        }
    }

    IEnumerator AnimTimer()
    {
        yield return new WaitForSeconds(_animTimer);
        animator.Play("Shine_Star");
        StartCoroutine(AnimTimer());
        
    }
}
