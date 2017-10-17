using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int getAddMaxHPValue(int lv)
    {
        return 0;
    }

    public int getCritDmg(float critRate)
    {
        if (UnityEngine.Random.Range(0, 1f) < critRate)
        {
            return (int)(10 * UnityEngine.Random.Range(0.5f, 1f));
        }
        return 0;
    }

    public int getDmgDescValue(int lv)
    {
        return 0;
    }
}
