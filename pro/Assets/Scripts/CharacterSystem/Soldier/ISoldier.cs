﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISoldier : ICharacter {

    protected SoldierFSMSystem mFSMSystem;
    public ISoldier():base()
    {
        makeFSM();
    }
    private void makeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();
        SoldierIdle idleState = new SoldierIdle(mFSMSystem, this);
        idleState.addTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChase chaseState = new SoldierChase(mFSMSystem, this);
        chaseState.addTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.addTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttack attackState = new SoldierAttack(mFSMSystem, this);
        attackState.addTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.addTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFSMSystem.addState(idleState,chaseState,attackState);
    }

    public void UpdateFSMAI(List<ICharacter> targets)
    {
        mFSMSystem.CurrState.reason(targets);
        mFSMSystem.CurrState.act(targets);
    }

}
