using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : ISoldierState
{
    public SoldierAttack(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c)
    {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }

    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void act(List<ICharacter> target)
    {
        if (target == null || target.Count == 0)
        {
            return;
        }
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mAttackTimer = 0;
            mCharacter.Attack(target[0]);
        }
    }

    public override void reason(List<ICharacter> target)
    {
        if (target == null || target.Count == 0)
        {
            mFSM.performTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(mCharacter.position, target[0].position);
        if (distance > mCharacter.AtkRange)
        {
            mFSM.performTransition(SoldierTransition.SeeEnemy);
            return;
        }
    }
}
