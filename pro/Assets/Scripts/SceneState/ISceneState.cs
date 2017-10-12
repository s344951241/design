using System;
using System.Collections.Generic;
using System.Text;

public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public ISceneState(string sceneName,SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }


    public string SceneName
    {
        get
        {
            return mSceneName;
        }

        set
        {
            mSceneName = value;
        }
    }
}
