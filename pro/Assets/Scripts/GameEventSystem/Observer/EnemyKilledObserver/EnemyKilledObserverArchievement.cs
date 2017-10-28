using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverArchievement : IGameEventObserver
{
    //private EnemyKilledSubject mSubject;
    private ArchievementSystem mArchievementSystem;
    public EnemyKilledObserverArchievement(ArchievementSystem system)
    {
        mArchievementSystem = system;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        //mSubject = subject as EnemyKilledSubject;
    }

    public override void Update()
    {
        mArchievementSystem.AddEnemyKilledCount();
    }
}
