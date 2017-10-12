using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : ISceneState
{
    public StartState(SceneStateController controller) : base("startScene",controller)
    {
    }
}
