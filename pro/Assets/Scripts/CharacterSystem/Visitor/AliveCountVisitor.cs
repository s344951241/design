using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCountVisitor :ICharacterVisitor{

    public int EnemyCount {
        get;
        private set;
    }

    public int SoldierCount {
        get;
        private set;
    }

    public void Reset()
    {
        EnemyCount = 0;
        SoldierCount = 0;
    }

    public override void VisitEnemy(IEnemy enemy)
    {
        if(!enemy.IsKilled)
            EnemyCount += 1;
    }

    public override void VisitSoldier(ISoldier soldier)
    {
        if(!soldier.IsKilled)
            SoldierCount += 1;
    }

}
