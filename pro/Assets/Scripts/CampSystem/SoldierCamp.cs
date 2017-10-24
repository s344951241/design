using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCamp : ICamp {

    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 pos,float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) : base(gameObject, name, icon, soldierType, pos,trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
    }

    public override int Lv
    {
        get
        {
            return mLv;
        }
    }

    public override WeaponType WeaponType
    {
        get
        {
            return mWeaponType;
        }
    }
}
