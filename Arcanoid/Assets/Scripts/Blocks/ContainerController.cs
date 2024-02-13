using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class ContainerController : MonoBehaviour
{
    public SizeType sizeType;
    public Block MyBlock;
    public BoxCollider2D _collider;
    public BoxCollider2D _MyComposite;
    private SpriteRenderer _spriteRenderer;

    public void Punch(int damage)
    {
        MyBlock.Punch(damage);
    }

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        RememberBlock();
    }
    void Start()
    {
        
    }

    public void CreateBlock(Block block) // в этом методе нельзя добавлять или вынимать контейнер из массива контейнеров
    {
        if (transform.GetComponentInChildren<Block>() == null)
        {
            LevelManager.LevelController.Model._ContainersFilled.Add(this);
            LevelManager.LevelController.Model._ContainersNull.Remove(this);
            _collider.enabled = true;
            _MyComposite.enabled = true;
            MyBlock = Instantiate(block, transform.position, Quaternion.identity, transform);
        }
        else
        {
            throw new Exception("В этом контейнере уже есть блок!");

        }
    }
    public void ReplaceBlock(Block block)
    {
        if (transform.GetComponentInChildren<Block>() == null)
        {
            throw new Exception("В этом контейнере нет блока на замену!");
        }
        else
        {
            MyBlock.DeleteInGame();
        }

            MyBlock = Instantiate(block, transform.position, Quaternion.identity, transform);
    }

    public void RememberBlock()
    {
        if (transform.GetComponentInChildren<Block>()==null)
        {
            MyBlock = null;
        }
        else
        {
            MyBlock = transform.GetComponentInChildren<Block>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
