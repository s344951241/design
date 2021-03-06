﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun :IWeapon{

    public WeaponGun(WeaponBaseAttr attr, GameObject gameObject) : base(attr, gameObject)
    {

    }
    protected override void playBulletEffect(Vector3 targetPos)
    {
        DoBulletEffect(0.05f, targetPos);
    }
    protected override void playSound()
    {
        doSound("GunShot");
    }

    protected override void setEffectDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}
