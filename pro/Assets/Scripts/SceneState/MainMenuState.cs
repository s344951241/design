using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{

    public MainMenuState(SceneStateController controller) : base("MainMenu", controller)
    {
    }

    public override void StateStart()
    {
        base.StateStart();
        GameObject.Find("StartBtn").GetComponent<Button>().onClick.AddListener(delegate
        {
            mController.SetState(new BattleState(mController));
        });
    }
}
