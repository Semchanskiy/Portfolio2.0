
using System;
using Unity.VisualScripting;
using UnityEngine;

public enum BlockType
{
    Standart,Reset,Stone,Double,Heal
}
public static class BlockDatabase
{
    [HideInInspector] private static Block Standart1x1 = Resources.Load<Block>("Prefabs/Blocks/StandartBlock 1x1");
    [HideInInspector] private static Block Standart1x2 = Resources.Load<Block>("Prefabs/Blocks/StandartBlock 1x2");
    [HideInInspector] private static Block Standart1x3 = Resources.Load<Block>("Prefabs/Blocks/StandartBlock 1x3");
    [HideInInspector] private static Block Standart2x2 = Resources.Load<Block>("Prefabs/Blocks/StandartBlock 2x2");

    [HideInInspector] private static Block Stone1x1 = Resources.Load<Block>("Prefabs/Blocks/StoneBlock 1x1");
    [HideInInspector] private static Block Stone1x2 = Resources.Load<Block>("Prefabs/Blocks/StoneBlock 1x2");
    [HideInInspector] private static Block Stone1x3 = Resources.Load<Block>("Prefabs/Blocks/StoneBlock 1x3");
    [HideInInspector] private static Block Stone2x2 = Resources.Load<Block>("Prefabs/Blocks/StoneBlock 2x2");

    [HideInInspector] public static Block Reset1x1 = Resources.Load<Block>("Prefabs/Blocks/ResetBlock 1x1");
    [HideInInspector] public static Block Reset1x2 = Resources.Load<Block>("Prefabs/Blocks/ResetBlock 1x2");
    [HideInInspector] public static Block Reset1x3 = Resources.Load<Block>("Prefabs/Blocks/ResetBlock 1x3");
    [HideInInspector] public static Block Reset2x2 = Resources.Load<Block>("Prefabs/Blocks/ResetBlock 2x2");

    [HideInInspector] public static Block Double1x1 = Resources.Load<Block>("Prefabs/Blocks/DoubleBlock 1x1");
    [HideInInspector] public static Block Double1x2 = Resources.Load<Block>("Prefabs/Blocks/DoubleBlock 1x2");
    [HideInInspector] public static Block Double1x3 = Resources.Load<Block>("Prefabs/Blocks/DoubleBlock 1x3");
    [HideInInspector] public static Block Double2x2 = Resources.Load<Block>("Prefabs/Blocks/DoubleBlock 2x2");

    [HideInInspector] public static Block Heal1x1 = Resources.Load<Block>("Prefabs/Blocks/HealBlock 1x1");
    [HideInInspector] public static Block Heal1x2 = Resources.Load<Block>("Prefabs/Blocks/HealBlock 1x2");
    [HideInInspector] public static Block Heal1x3 = Resources.Load<Block>("Prefabs/Blocks/HealBlock 1x3");
    [HideInInspector] public static Block Heal2x2 = Resources.Load<Block>("Prefabs/Blocks/HealBlock 2x2");

    public static Block GetBlock(BlockType blockType, ContainerController container)
    {
        switch (blockType)
        {
            case BlockType.Standart:
               return GetStandartBlock(container);
            case BlockType.Reset:
                return GetResetBlock(container);
            case BlockType.Stone:
                return GetStoneBlock(container);
            case BlockType.Double:
                return GetDoubleBlock(container);
            case BlockType.Heal:
                return GetHealBlock(container);
            default:
                throw new Exception("Указанного типа блока не существует в перечислении");
        }
    }
    private static Block GetStandartBlock(ContainerController container)
    {
        Block block = null;
        SizeType sizeType = container.sizeType;

        switch (sizeType)
        {
            case SizeType.OneOnOne:
                block = Standart1x1;
                break;
            case SizeType.OneOnTwo:
                block = Standart1x2;
                break;
            case SizeType.OneOnThree:
                block = Standart1x3;
                break;
            case SizeType.TwoOnTwo:
                block = Standart2x2;
                break;
        }
        return block;
    }
    private static Block GetStoneBlock(ContainerController container)
    {
        Block block = null;
        SizeType sizeType = container.sizeType;

        switch (sizeType)
        {
            case SizeType.OneOnOne:
                block = Stone1x1;
                break;
            case SizeType.OneOnTwo:
                block = Stone1x2;
                break;
            case SizeType.OneOnThree:
                block = Stone1x3;
                break;
            case SizeType.TwoOnTwo:
                block = Stone2x2;
                break;
        }
        return block;
    }
    private static Block GetResetBlock(ContainerController container)
    {
        Block block = null;
        SizeType sizeType = container.sizeType;

        switch (sizeType)
        {
            case SizeType.OneOnOne:
                block = Reset1x1;
                break;
            case SizeType.OneOnTwo:
                block = Reset1x2;
                break;
            case SizeType.OneOnThree:
                block = Reset1x3;
                break;
            case SizeType.TwoOnTwo:
                block = Reset2x2;
                break;
        }
        return block;
    }
    private static Block GetDoubleBlock(ContainerController container)
    {
        Block block = null;
        SizeType sizeType = container.sizeType;

        switch (sizeType)
        {
            case SizeType.OneOnOne:
                block = Double1x1;
                break;
            case SizeType.OneOnTwo:
                block = Double1x2;
                break;
            case SizeType.OneOnThree:
                block = Double1x3;
                break;
            case SizeType.TwoOnTwo:
                block = Double2x2;
                break;
        }
        return block;
    }
    private static Block GetHealBlock(ContainerController container)
    {
        Block block = null;
        SizeType sizeType = container.sizeType;

        switch (sizeType)
        {
            case SizeType.OneOnOne:
                block = Heal1x1;
                break;
            case SizeType.OneOnTwo:
                block = Heal1x2;
                break;
            case SizeType.OneOnThree:
                block = Heal1x3;
                break;
            case SizeType.TwoOnTwo:
                block = Heal2x2;
                break;
        }
        return block;
    }
}
