using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttrStrategy : IAttrStrategy
{
    public int getAddMaxHPValue(int lv)
    {
        return (lv - 1) * 110;
    }

    public int getCritDmg(float critRate)
    {
        return 0;

    }

    public int getDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }
}
