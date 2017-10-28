using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain
}
public abstract class ISoldier : ICharacter {

  

    protected SoldierFSMSystem mFSMSystem;
    public ISoldier():base()
    {
        makeFSM();
    }
    private void makeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.addTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.addTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.addTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
        attackState.addTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.addTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFSMSystem.addState(idleState,chaseState,attackState);
    }

    public void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled)
            return;
        mFSMSystem.CurrState.reason(targets);
        mFSMSystem.CurrState.act(targets);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled)
            return;
        base.UnderAttack(damage);
        if (mAttr.CurHp <= 0)
        {
            playSound();
            playEffect();
            killed();
        }
    }

    protected abstract void playSound();
    protected abstract void playEffect();

    public override void killed()
    {
        base.killed();
        GameFacade.Instance.NotifySubject(GameEventType.SoldierKilled);
    }

}
