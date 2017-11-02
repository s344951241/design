using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : IEnemy
{
    public override void playEffect()
    {
        doPlayEffect("ElfHitEffect");
    }
}
