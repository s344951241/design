using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon {

    public override void Fire(Vector3 targetPos)
    {
        Debug.Log("显示特效");
        Debug.Log("播放声音");
    }
}
