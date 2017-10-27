using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler{

    protected int mLv;//关卡
    protected IStageHandler mNextHandler;
    protected StageSystem mStageSystem;
    private int mCountToFinish;

    public IStageHandler(StageSystem system,int lv,int countToFinish)
    {
        mStageSystem = system;
        mLv = lv;
        mCountToFinish = countToFinish;
    }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public void Handle(int lv)
    {
        if (lv == mLv)
        {
            UpdateStage();
            CheckIsFinished();//检查关卡是否结束
        }
        else
        {
            if(mNextHandler!=null)
            {
                mNextHandler.Handle(lv);
            }
        }
    }

    protected virtual void UpdateStage() { }
    private void CheckIsFinished()
    {
        if (mStageSystem.GetCountOfEnemyKilled() >= mCountToFinish)
        {
            mStageSystem.EnterNextStage();
        }
    }
}
