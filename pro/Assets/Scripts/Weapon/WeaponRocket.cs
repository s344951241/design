using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon {
    public WeaponRocket(int atk, int atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override void playBulletEffect(Vector3 targetPos)
    {
        DoBulletEffect(0.1f, targetPos);
    }
    protected override void playSound()
    {
        doSound("RocketShot");
    }
    protected override void setEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}
