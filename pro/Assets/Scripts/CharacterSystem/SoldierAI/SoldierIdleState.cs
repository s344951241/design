using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : ISoldierState
{

    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Idle;
    }
    public override void act(List<ICharacter> target)
    {
        mCharacter.playAnim("stand");
    }

    public override void reason(List<ICharacter> target)
    {
        if (target != null && target.Count != 0)
        {
            mFSM.performTransition(SoldierTransition.SeeEnemy);
        }
    }
}
