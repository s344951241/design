using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateController {

    private ISceneState mState;

    public void StateUpdate()
    {
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}
