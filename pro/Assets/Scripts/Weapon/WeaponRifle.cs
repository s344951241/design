﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle :IWeapon{
    protected override void playBulletEffect(Vector3 targetPos)
    {
        DoBulletEffect(0.3f, targetPos);
    }
    protected override void playSound()
    {
        doSound("RifleShot");
    }
    protected override void setEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}