using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private ArchievementSystem mArchievementSystem;
    public NewStageObserverAchievement(ArchievementSystem system)
    {
        mArchievementSystem = system;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mArchievementSystem.SetMaxStageLv(mSubject.StageCount);
    }
}
