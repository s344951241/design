using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptain : ISoldier
{
    protected override void playEffect()
    {
        doPlayEffect("CaptainDeadEffect");
    }

    protected override void playSound()
    {
        doPlaySound("CaptainDeath");
    }
}
