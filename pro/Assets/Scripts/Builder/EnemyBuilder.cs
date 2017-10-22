using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 pos, int lv) : base(character, t, weaponType, pos, lv)
    {
    }

    public override void addCharacterAttr()
    {
        BaseAttr baseAttr = FactoryManager.AttrFactory.getBaseAttr(mType);
        ICharacterAttr attr = new ICharacterAttr(new EnemyAttrStrategy(), mLv,baseAttr);
        mCharacter.Attr = attr;
    }

    public override void addGameObject()
    {
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(mCharacter.Attr.BaseAttr.PrefabName);
        characterGO.transform.position = mPos;
        mCharacter.GameObject = characterGO;
    }

    public override void addWeapon()
    {
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter getResult()
    {
        return mCharacter;
    }
}

	
