using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private PlatformController _platform;
    private Ball _startBall;

    [SerializeField] public PlatformController PlatformPrefab;
    [SerializeField] public Ball BallPrefab;
    [SerializeField] public LevelModel Model;
    [HideInInspector] public CompositeBlock ContainersBlocks;
    private PlayerData PlayerData;

    private void Awake()
    {
        ContainersBlocks = FindObjectOfType<CompositeBlock>();
        Model = new LevelModel();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void Initialization()
    {
        LoadData();
        PreparationFirstTurn();
    }

    private void CreatePlatform()
    {
        _platform = Instantiate(PlatformPrefab, new Vector3(-12f, -0.66f),
            Quaternion.identity);// (-12f, -3.25f),
    }

    private void CreateStartBall()
    {
        _startBall = Instantiate(BallPrefab, new Vector3(-11.2f, 2.02f),
            Quaternion.identity);
        _startBall._platform = _platform;
    }

    private void LoadData()
    {
        PlayerData = FindObjectOfType<PlayerData>();
        Model._PoolBalls = PlayerData._Balls;
        Model._Artifacts = PlayerData._Artifacts;

        LoadDataContainers();
        
    }

    public void LoadDataContainers()
    {
        Model._ContainersOnTable.AddRange(FindObjectsOfType<ContainerController>());
        foreach (var container in Model._ContainersOnTable)
        {
            if (container.transform.GetComponentInChildren<Block>() == null)
            {
                Model._ContainersNull.Add(container); 
            }
            else
            {
                Model._ContainersFilled.Add(container);
            }
        }
    }
    public void FilledNullContainers() // заполнить пустые контейнеры
    {
        List<ContainerController> useContainers = new List<ContainerController>();
        useContainers.AddRange(Model._ContainersNull);

        foreach (var container in useContainers)
        {
            container.CreateBlock(BlockDatabase.GetBlock(BlockType.Standart,container));
        }
    }
    public void ActivateArtifacts()
    {
        foreach (var Artifact in Model._Artifacts)
        {
            Artifact.ActivationBeforeGame();
        }
    }
    public void ActivateEnemyStartSpells()
    {

    }
    public void PreparationFirstTurn()
    {
        FilledNullContainers();
        CreatePlatform();
        ActivateArtifacts();
        CreateStartBall();
        CreateResetBlock();
    }

    public ContainerController FindContainerNull()
    {
        ContainerController container = null;
        if (Model._ContainersNull.Count != 0)
        { 
            container = Model._ContainersNull[Random.Range(0, Model._ContainersNull.Count)];
            return container;
        }
        else
        {
            Debug.Log("Нет пустых контейнеров");
            return null;
        }
    } // совершенно любой пустой контейнер
    public ContainerController FindContainerFilled()
    {
        ContainerController container = null;
        if (Model._ContainersFilled.Count != 0)
        {
            container = Model._ContainersFilled[Random.Range(0, Model._ContainersFilled.Count)];
            return container;
        }
        else
        {
            Debug.Log("Нет полных контейнеров");
            return null;
        }
    } // совершенно любой заполненный контейнер
    public ContainerController FindContainerFilledStandartBlock()
    {
        ContainerController container = null;
        List<ContainerController> useContainers = new List<ContainerController>();

        foreach (var contaiver in Model._ContainersFilled)
        {
            if (container.transform.GetComponentInChildren<Block>().blockType == BlockType.Standart)
            {
                useContainers.Add(container);
            }
        }
        int lengthUseContainers = useContainers.Count;

        if (lengthUseContainers != 0)
        {
            container = Model._ContainersFilled[Random.Range(0, lengthUseContainers)];
            return container;
        }
        else
        {
            Debug.Log("Нет полных контейнеров с стандартными блоками");
            return null;
        }
    } // совершенно любой заполненный контейнер с стандартным блоком

    public void ReplaceBlock(int count, BlockType blockType)
    {
        while (count > 0)
        {
            ContainerController useContainer = FindContainerFilled();
            useContainer.ReplaceBlock(BlockDatabase.GetBlock(blockType, useContainer));
            count--;
        }
    }
    
    public void CreateResetBlock()
    {
        int countResetBlockAtTable = 0;
        foreach (var container in Model._ContainersFilled) // счет существующих ресет блоков на столе
        {
            if (container.MyBlock.GetComponent<ResetBlock>() != null)
            {
                countResetBlockAtTable++;
            }
        }


        if (countResetBlockAtTable == 0) // в последствии заменить на количество ресет проков которые могут находится на столе одновременно
        {
            List <ContainerController> useContainers = new List<ContainerController>();
            foreach (var container in Model._ContainersFilled)
            {
                if (container.transform.GetComponentInChildren<Block>().blockType == BlockType.Standart)
                {
                    useContainers.Add(container);
                }
            }
            int length = useContainers.Count;

            if (length > 0)
            {
                ContainerController useContainer = useContainers[Random.Range(0,length)];

                useContainer.ReplaceBlock(BlockDatabase.GetBlock(BlockType.Reset,useContainer));
            }
        }
    }
    public void StartTurn()
    {

    }
    public void CheckEndTurn()
    {
        if (Model._BallsInGame.Count <= 0)
        {
            PlayerAttack();
        }
    }
    public void PlayerAttack()
    {
        ApplyDamage(-Model.accumulatedDamage);//обнулить счетчик урона
        EnemyTurn();
    }
    public void EnemyTurn()
    {
        PreparationPlayerTurn();
    }
    public void PreparationPlayerTurn()
    {
        CreateStartBall();
        _platform.FindStartBall();
    }
    public void SkipBall()
    {

    }

    public void ApplyDamage(int damage)
    {
        Model.accumulatedDamage += damage;
        LevelManager.UIController.ChangeAccumulatedDamage(Model.accumulatedDamage);
        
    }

}
