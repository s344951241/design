using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IUI {

    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLv;
    private Text mWeaponLv;
    private Button mUp;
    private Button mWeaponUp;
    private Button mTrain;
    private Button mCancelTrain;
    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init()
    {
        base.Init();
        mRootUI = UnityTool.FindChild(UITool.GetCanvas(),"CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLv = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLv = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mUp = UITool.FindChild<Button>(mRootUI, "CampUp");
        mWeaponUp = UITool.FindChild<Button>(mRootUI, "WeaponUp");
        mTrain = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrain= UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChild<Text>(mRootUI, "TrainCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

        Hide();
    }

    public void showCampInfo(ICamp camp)
    {
        Show();
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.Icon);
        mCampName.text = camp.Name;
        mCampLv.text = camp.Lv.ToString();
        showWeaponLv(camp.WeaponType);

    }

    private void showWeaponLv(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Gun:
                mWeaponLv.text = "手枪";
                break;
            case WeaponType.Rifle:
                mWeaponLv.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLv.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }
}
