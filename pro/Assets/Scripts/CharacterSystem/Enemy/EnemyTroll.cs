using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : IEnemy {

    public override void playEffect()
    {
        doPlayEffect("TrollHitEffect");
    }
}
