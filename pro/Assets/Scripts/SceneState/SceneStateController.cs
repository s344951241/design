using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneStateController {

    private ISceneState mState;
    AsyncOperation mAO;
    private bool mIsStart = false;
    public void SetState(ISceneState state,bool isLoadScene = true)
    {
        if (mState != null)
        {
            mState.StateEnd();//切换场景状态的清理工作
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsStart = false;
        }
        else {
            mState.StateStart();
            mIsStart = true;
        }
       
    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false)
            return;
        if (mIsStart==false&& mAO != null && mAO.isDone)
        {
            mState.StateStart();
            mIsStart = true;
        }
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}
