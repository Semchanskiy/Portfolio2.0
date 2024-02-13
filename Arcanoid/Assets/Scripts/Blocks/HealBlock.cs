using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBlock : Block
{
    private HeroController Hero;
    private Artifact Podoroshnic; // в последствии прокинуть ссылку на артифакт который создает этот предмет чтобы блок знал какого уровня артифакт
    override protected void Start()
    {
        base.Start();
        Hero = FindObjectOfType<HeroController>();
    }

    
}
