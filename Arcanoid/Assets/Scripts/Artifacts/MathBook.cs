using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MathBook : Artifact
{
    [SerializeField] private Block prefabBlock;

    public override string Description_Level1 => "� ������ ���� ������� ���� ����, ������� ��� ���������� ��������� ����������� ����";
    public override string Description_Level2 => "� ������ ���� ������� ��� �����, ������� ��� ���������� ��������� ����������� ����";
    public override string Description_Level3 => "� ������ ���� ������� ���� ����, ������� ��� ���������� ��������� ����������� ����. ��� ���������� ����� �� ���������� �����";

    override public void ActivationBeforeGame() // ��������� ����� �����
    {
        //List<Block> newListBlocks = new List<Block>();
        //List<Block> blocksOnTable = LevelManager.LevelController.Model._BlocksOnTable;
        //foreach (var block in blocksOnTable) //��������� � ����� ���� ��� ����� ������� ����� ���� ���������� �������������� ��� ����� ���������
        //{
        //    if (block.sizeType == SizeType.OneOnTwo && block.blockType == Type.Standart)
        //    {
        //        newListBlocks.Add(block);
        //    }
        //}

        //Vector2 positoinNewBlock;
        //Block newBlock;
        //foreach (var block in newListBlocks)
        //{
        //    LevelManager.LevelController.Model._BlocksOnTable.Remove(block);
        //    block.DeleteInGame();
        //    positoinNewBlock = block.gameObject.transform.position;
        //    newBlock = Instantiate(prefabBlock, positoinNewBlock, Quaternion.identity);
        //    newBlock.transform.parent = LevelManager.LevelController.ContainersBlocks.transform;
        //    LevelManager.LevelController.Model._BlocksOnTable.Add(newBlock);
        //}
    }
}
