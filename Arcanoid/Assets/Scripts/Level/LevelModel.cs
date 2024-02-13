using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    public List<Ball> _PoolBalls = new List<Ball>();
    public List<Ball> _DiscardBalls = new List<Ball>();
    public List<Ball> _BallsInGame = new List<Ball>();

    public List<Artifact> _Artifacts = null;

    public List<ContainerController> _ContainersOnTable = new List<ContainerController>();
    public List<ContainerController> _ContainersNull = new List<ContainerController>();
    public List<ContainerController> _ContainersFilled = new List<ContainerController>();

    public List<Block> _blockIsCreateWhenReset = new List<Block>();// какие блоки еще создавать когда происходит обновление стола


    public int accumulatedDamage = 0;

    public void Initialization()
    {
        
    }
    void Start()
    {
        Initialization();
    }
}
