using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBlock : Block
{
    private HeroController Hero;
    private Artifact Podoroshnic; // � ����������� ��������� ������ �� �������� ������� ������� ���� ������� ����� ���� ���� ������ ������ ��������
    override protected void Start()
    {
        base.Start();
        Hero = FindObjectOfType<HeroController>();
    }

    
}
