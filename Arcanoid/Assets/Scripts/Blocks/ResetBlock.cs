using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ResetBlock : Block
{
    public LayerMask LayerMask;
    public override void DestroyBlock(int damage)
    {
        base.DestroyBlock(damage);

        List<ContainerController> useContainers = new List<ContainerController>();
        foreach (var container in LevelManager.LevelController.Model._ContainersNull)
        {
            if (Physics2D.OverlapBox(container.transform.position, container._collider.size, 0f, LayerMask))
            {

            }
            else
            {
                if (container != _container)
                {
                    useContainers.Add(container);
                }
            }
        }
        foreach (var container in useContainers)
        {
            container.CreateBlock(BlockDatabase.GetBlock(BlockType.Standart,container));
        }

        LevelManager.LevelController.CreateResetBlock();

        if (LevelManager.LevelController.Model._blockIsCreateWhenReset.Count != 0)
        {
            foreach (var block in LevelManager.LevelController.Model._blockIsCreateWhenReset)
            {
                ContainerController container = LevelManager.LevelController.FindContainerFilled();
                container.CreateBlock(block);
                
            }
        }

    }
}
