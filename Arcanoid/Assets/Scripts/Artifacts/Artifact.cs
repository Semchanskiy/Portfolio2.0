using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public abstract class Artifact : MonoBehaviour
{
    public string Name;
    public virtual string Description { get; }
    public virtual string Description_Level1 { get; }
    public virtual string Description_Level2 { get; }
    public virtual string Description_Level3 { get; }

    [SerializeField] protected Sprite sprite;

    public int level = 1;


    public virtual void LevelUp()
    {
        level++;
    }

    protected virtual void Awake()
    {
        
    }
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public virtual void ActivationBeforeGame() // активация перед игрой
    {
        switch (level)
        {
            case 1:
            {
                    LevelManager.LevelController.ReplaceBlock(1,BlockType.Double);
                break;
            }
            case 2:
            {
                break;
            }
            case 3:
            {
                break;
            }
        }
    }

    public virtual void ActivationAfterGame() // активация после игры
    {

    }

    protected virtual void ActivationWhenReceiving() // активация при получении
    {

    }

}
