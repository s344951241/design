using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base("battleScene", controller)
    {
    }

    public override void StateStart()
    {
        base.StateStart();
        GameFacade.Instance.Init();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        base.StateUpdate();
        GameFacade.Instance.Update();
    }
    public override void StateEnd()
    {
        base.StateEnd();
        GameFacade.Instance.Release();
    }
}
