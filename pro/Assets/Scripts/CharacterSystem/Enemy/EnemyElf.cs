using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : IEnemy
{
    protected override void playEffect()
    {
        doPlayEffect("ElfHitEffect");
    }
}
