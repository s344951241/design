﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}
public abstract class IEnemy : ICharacter {
    protected EnemyFSMSystem mFSMSystem;
    public IEnemy() : base()
    {
        makeFSM();
    }


    public override void  UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled)
            return;
        mFSMSystem.CurrState.reason(targets);
        mFSMSystem.CurrState.act(targets);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
    private void makeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.addTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.addTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.addState(chaseState, attackState);

    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled)
            return;
        base.UnderAttack(damage);
        playEffect();
        if (mAttr.CurHp <= 0)
        {
            killed();
        }
    }

    public abstract void playEffect();

    public override void killed()
    {
        base.killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }
}
