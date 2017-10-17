using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : IEnemyState
{
    public EnemyChase(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }
    private Vector3 mTargetPos;
    public override void doBeforeEntering()
    {
        mTargetPos = GameFacade.Instance.GetEnemyTargetPos();
    }
    public override void act(List<ICharacter> target)
    {
        if (target != null && target.Count > 0)
        {
            mCharacter.moveTo(target[0].position);
        }
        else
        {
            mCharacter.moveTo(mTargetPos);
        }
    }

    public override void reason(List<ICharacter> target)
    {
        if (target != null && target.Count > 0)
        {
            float distance = Vector2.Distance(mCharacter.position, target[0].position);
            if (distance < mCharacter.AtkRange)
            {
                mFSM.performTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
