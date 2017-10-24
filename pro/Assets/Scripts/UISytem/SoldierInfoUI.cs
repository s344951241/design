using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldierInfoUI : IUI {

    private Image mSoldierIcon;
    private Image mSoldierName;
    private Text mHPText;
    private Slider mHPSlider;
    private Text mLv;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITool.FindChild<Image>(mRootUI, "SoldierName");
        mHPText = UITool.FindChild<Text>(mRootUI, "hp");
        mHPSlider = UITool.FindChild<Slider>(mRootUI, "hpSlider");
        mLv = UITool.FindChild<Text>(mRootUI, "lv");
        mAtk = UITool.FindChild<Text>(mRootUI, "atk");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "range");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "speed");

        Hide();
    }
}
