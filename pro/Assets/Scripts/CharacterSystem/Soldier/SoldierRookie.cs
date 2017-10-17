using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRookie : ISoldier
{
    protected override void playEffect()
    {
        doPlayEffect("RookieDeadEffect");
    }

    protected override void playSound()
    {
        doPlaySound("RookieDeath");
    }
}
