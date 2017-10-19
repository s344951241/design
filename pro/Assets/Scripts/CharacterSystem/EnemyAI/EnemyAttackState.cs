using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Attack;
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
            mFSM.performTransition(EnemyTransition.LostSoldier);
        }
        else
        {
            float distance = Vector2.Distance(mCharacter.position, target[0].position);
            if (distance > mCharacter.AtkRange)
            {
                mFSM.performTransition(EnemyTransition.LostSoldier);
            }
        }

    }
}
