using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{
    public StartState(SceneStateController controller) : base("startScene",controller)
    {
    }

    private Image mLogo;
    private float mWaiteTime;
    public override void StateStart()
    {
        base.StateStart();
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
        mWaiteTime = 2;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        mLogo.color = Color.Lerp(mLogo.color, Color.white, 0.5f * Time.deltaTime);
        mWaiteTime -= Time.deltaTime;
        if (mWaiteTime < 0)
        {
            mController.SetState(new MainMenuState(mController));
        }
    }
}
