using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState
{
    public BattleState(string sceneName, SceneStateController controller) : base("battleScene", controller)
    {
    }
}
