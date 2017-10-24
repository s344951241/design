using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : IUI {

    private Text mCurrentStageLv;
    private Button mContinueBtn;
    private Button mBackMenuBtn;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

        mCurrentStageLv = UITool.FindChild<Text>(mRootUI, "stage");
        mContinueBtn = UITool.FindChild<Button>(mRootUI, "continueBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "backBtn");

        Hide();
    }
}
