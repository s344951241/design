using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon {
    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
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
