using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }
    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
    }

    public void SetMaxStageLv(int stageLv)
    {
        if (stageLv > mMaxStageLv)
            mMaxStageLv = stageLv;
    }

    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyKilledCount = mEnemyKilledCount;
        memento.SoldierKilledCount = mSoldierKilledCount;
        memento.MaxStageLv = mMaxStageLv;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.EnemyKilledCount;
        mSoldierKilledCount = memento.SoldierKilledCount;
        mMaxStageLv = memento.MaxStageLv;
    }
}
