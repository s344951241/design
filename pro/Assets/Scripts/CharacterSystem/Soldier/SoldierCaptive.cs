using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;

        ICharacterAttr attr = new ICharacterAttr(mEnemy.Attr.Strategy, 1, mEnemy.Attr.BaseAttr);
        this.Attr = attr;

        this.GameObject = mEnemy.GameObject;
        this.Weapon = mEnemy.Weapon;

    }

    protected override void playEffect()
    {
        mEnemy.playEffect();
    }

    protected override void playSound()
    {
        
    }
}
