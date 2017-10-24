using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Chase;
    }
    public override void act(List<ICharacter> target)
    {
        if (target != null && target.Count > 0)
        {
            mCharacter.moveTo(target[0].position);
        }
    }

    public override void reason(List<ICharacter> target)
    {
        if (target == null || target.Count == 0)
        {
            mFSM.performTransition(SoldierTransition.NoEnemy);
        }
        float distance = Vector3.Distance(target[0].position, mCharacter.position);
        if (distance < mCharacter.AtkRange)
        {
            mFSM.performTransition(SoldierTransition.CanAttack);
        }
    }
}
