using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, BaseAttr> mBaseAttr;
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttr;
  
    public AttrFactory()
    {
        mBaseAttr = new Dictionary<Type, BaseAttr>();
        mWeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>(); 
        InitBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitBaseAttr()
    {
        mBaseAttr.Add(typeof(SoldierRookie), new BaseAttr("新兵", 80, 2.5f, "RookieIcon", "Soldier2", 0));
        mBaseAttr.Add(typeof(SoldierSergeant), new BaseAttr("中士", 90, 3, "SergeantIcon", "Soldier3", 0));
        mBaseAttr.Add(typeof(SoldierCaptain), new BaseAttr("上尉", 100, 3, "CaptainIcon", "Soldier1", 0));

        mBaseAttr.Add(typeof(EnemyElf), new BaseAttr("精灵", 100, 3, "ElfIcon", "Enemy1",0.2f));
        mBaseAttr.Add(typeof(EnemyOgre), new BaseAttr("怪物", 120, 2, "OgreIcon", "Enemy2", 0.3f));
        mBaseAttr.Add(typeof(EnemyTroll), new BaseAttr("巨魔", 200, 1, "TrollIcon", "Enemy3", 0.5f));

       
    }

    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttr.Add(WeaponType.Gun, new WeaponBaseAttr("手枪", 20, 5, "WeaponGun"));
        mWeaponBaseAttr.Add(WeaponType.Gun, new WeaponBaseAttr("长枪", 30, 7, "WeaponRifle"));
        mWeaponBaseAttr.Add(WeaponType.Gun, new WeaponBaseAttr("火箭", 40, 8, "WeaponRocket"));
    }

    public BaseAttr getBaseAttr(Type t)
    {
        if (mBaseAttr == null)
            mBaseAttr = new Dictionary<Type, BaseAttr>();
        if (!mBaseAttr.ContainsKey(t))
        {
            Debug.LogError("can't find baseAttr by type"+t);
            return null;
        }
        return mBaseAttr[t];
    }

    public WeaponBaseAttr getWeaponBaseAttr(WeaponType type)
    {
        if (mWeaponBaseAttr == null)
            mWeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>();
        if (!mWeaponBaseAttr.ContainsKey(type))
        {
            Debug.LogError("can't find weaponBaseAttr by WeaponType");
            return null;
        }
        return mWeaponBaseAttr[type];
    }
}
