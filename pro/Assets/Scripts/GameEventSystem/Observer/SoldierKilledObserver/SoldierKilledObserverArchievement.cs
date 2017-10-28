using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverArchievement : IGameEventObserver
{
    private ArchievementSystem mArchievementSystem;
    public SoldierKilledObserverArchievement(ArchievementSystem system)
    {
        mArchievementSystem = system;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        mArchievementSystem.AddSoldierKilledCount();
    }
}
