using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy : ICharacter {
    protected EnemyFSMSystem mFSMSystem;
    public IEnemy() : base()
    {
        makeFSM();
    }


    public void updateFSMAI(List<ICharacter> targets)
    {
        mFSMSystem.CurrState.reason(targets);
        mFSMSystem.CurrState.reason(targets);
    }
    private void makeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChase chaseState = new EnemyChase(mFSMSystem, this);
        chaseState.addTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttack attackState = new EnemyAttack(mFSMSystem, this);
        attackState.addTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.addState(chaseState, attackState);

    }

    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        playEffect();
        if (mAttr.CurHp <= 0)
        {
            killed();
        }
    }

    protected abstract void playEffect();
}
