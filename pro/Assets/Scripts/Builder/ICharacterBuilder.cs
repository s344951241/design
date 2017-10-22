using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ICharacterBuilder{
    protected Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mPos;
    protected int mLv;
    protected ICharacter mCharacter;
    public ICharacterBuilder(ICharacter character, Type t,WeaponType weaponType,Vector3 pos,int lv)
    {
        mType = t;
        mWeaponType = weaponType;
        mPos = pos;
        mLv = lv;
    }

    public abstract void addCharacterAttr();
    public abstract void addGameObject();
    public abstract void addWeapon();

    public abstract ICharacter getResult();
}
